using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Copying_files.Classes
{
    public class Copying
    {
        private static readonly int bufferSize = 4096;

        private byte[] buffer = new byte[bufferSize];
        private string pathForCopy;
        private string pathForPaste;

        AutoResetEvent autoResetEvent = new AutoResetEvent(false);
        CancellationTokenSource tokenSource = new CancellationTokenSource();
        CancellationToken token;

        public IProgress<int> Progress;
        private Task WriteTask;
        private Task ReadTask;

        public Copying(IProgress<int> progress)
        {
            Progress = progress;
            copyingIsComplete = true;
        }

        private bool copyingIsComplete;
        public bool CopyingIsComplete
        {
            private set
            {
                copyingIsComplete = value;
            }
            get
            {
                return copyingIsComplete;
            }
        }

        public long StartCopying(string[] copyingPaths, string PastePath)
        {
            CopyingIsComplete = false;
            token = tokenSource.Token;

            pathForPaste = PastePath;

            long MaxLenght = 0;
            foreach (var file in copyingPaths)
            {
                MaxLenght += new FileInfo(file).Length; 
            }

            var task = new Task(Paths => 
            {
                foreach (var path in (string[])Paths)
                {
                    pathForCopy = path;

                    ReadTask = new Task(() => Read(), token);
                    ReadTask.Start();

                    WriteTask = new Task(() => Write(), token);
                    WriteTask.Start();

                    Task.WaitAny(ReadTask, WriteTask);
                    if (token.IsCancellationRequested)
                    {
                        token.ThrowIfCancellationRequested();
                        return;
                    }
                }
            }, copyingPaths, token);
            task.Start();

            task.ContinueWith(t => MessageBox.Show("Copying done!"),
                TaskContinuationOptions.OnlyOnRanToCompletion);

            task.ContinueWith(t => 
            {
                File.Delete(pathForPaste + Path.GetFileName(pathForCopy));
                MessageBox.Show("Canceled");
                CopyingIsComplete = true;
            },TaskContinuationOptions.OnlyOnCanceled);

            return MaxLenght;
        }
        public void CopyDirrectry(string copyingPath, string pastePath)
        {
            pathForCopy = copyingPath;
            pathForPaste = pastePath;

            var task = new Task(() => { CopyAllDepth(pathForCopy, pathForPaste); }, token);
            task.Start();
        }

        private void CopyAllDepth(string copyPath, string pastePath)
        {
            Directory.CreateDirectory(pastePath + new DirectoryInfo(copyPath).Name);
            pathForPaste = pastePath + new DirectoryInfo(copyPath).Name + @"\";

            var entities = Directory.EnumerateFiles(copyPath, "*");
            foreach (var item in entities)
            {
                pathForCopy = item;
                ReadTask = new Task(() => Read(), token);
                ReadTask.Start();

                WriteTask = new Task(() => Write(), token);
                WriteTask.Start();

                Task.WaitAny(ReadTask, WriteTask);


                if (token.IsCancellationRequested)
                {
                    token.ThrowIfCancellationRequested();
                    return;
                }
            }

            entities = Directory.EnumerateDirectories(copyPath, "*");
            foreach (var item in entities)
            {
                CopyAllDepth(item, pastePath + new DirectoryInfo(copyPath).Name + @"\" + new DirectoryInfo(item).Name);
            }
        }

        /*
         pathForPaste = pastePath +  new DirectoryInfo(copyPath).Name;
            Directory.CreateDirectory(pathForPaste);
            pathForPaste += @"\";

            var entities = Directory.EnumerateFiles(copyPath, "*");
            foreach (var item in entities)
            {
                pathForCopy = item;
                ReadTask = new Task(() => Read(), token);
                ReadTask.Start();

                WriteTask = new Task(() => Write(), token);
                WriteTask.Start();

                Task.WaitAny(ReadTask, WriteTask);


                if (token.IsCancellationRequested)
                {
                    token.ThrowIfCancellationRequested();
                    return;
                }
            }

            entities = Directory.EnumerateDirectories(copyPath, "*");
            foreach (var item in entities)
            {
                pathForCopy = item + @"\";
                CopyAllDepth(item, pastePath + new DirectoryInfo(copyPath).Name);
                if (token.IsCancellationRequested)
                {
                    token.ThrowIfCancellationRequested();
                    return;
                }
            }
             
             */

        private void Read()
        {
            using (FileStream readStream = new FileStream(pathForCopy, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize, true))
            {
                if (readStream.Length > bufferSize)
                {
                    buffer = new byte[bufferSize];
                    long currPoss;
                    for (currPoss = 0; currPoss < Math.Truncate((double)readStream.Length / bufferSize); currPoss++)
                    {
                        readStream.Read(buffer, 0, bufferSize);

                        autoResetEvent.Set();
                        autoResetEvent.WaitOne();
                        Progress.Report(1);
                    }
                    if (currPoss * bufferSize < readStream.Length)
                    {
                        buffer = new byte[readStream.Length - currPoss * bufferSize];
                        readStream.Read(buffer, 0, (int)(readStream.Length - currPoss * bufferSize));
                    }
                    Progress.Report(1);
                }
                else
                {
                    buffer = new byte[readStream.Length];
                    readStream.Read(buffer, 0, (int)(readStream.Length));
                }
                CopyingIsComplete = true;
                autoResetEvent.Set();
            }

        }
        private void Write()
        {
            using (FileStream writeStream = new FileStream(pathForPaste + Path.GetFileName(pathForCopy), FileMode.Create, FileAccess.Write))
            {
                writeStream.Position = 0;
                do
                {
                    autoResetEvent.WaitOne();

                    writeStream.Write(buffer, 0, (buffer.Length));
                    autoResetEvent.Set();
                } while (CopyingIsComplete == false);
            }
   
        }
        
        public void CancelCopy()
        {
            tokenSource.Cancel();
            autoResetEvent.Set();
            autoResetEvent.Set();
        }
    }
}