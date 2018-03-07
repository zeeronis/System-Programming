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

        IProgress<int> Progress;
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

        public int StartCopying(string CopyPath, string PastePath)
        {
            CopyingIsComplete = false;
            token = tokenSource.Token;
            pathForCopy = CopyPath;
            pathForPaste = PastePath;

            int MaxValue;
            using (FileStream readStream = new FileStream(pathForCopy, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize, true))
            {
                MaxValue = (int)Math.Ceiling(readStream.Length / (double)bufferSize);
            }


            ReadTask = new Task(() => Read(), token);
            ReadTask.Start();

            WriteTask = new Task(() => Write(), token);
            WriteTask.Start();

            WriteTask.ContinueWith(t => MessageBox.Show("Copying done!"),
                TaskContinuationOptions.OnlyOnRanToCompletion);

            WriteTask.ContinueWith(t => 
            {
                File.Delete(pathForPaste + Path.GetFileName(pathForCopy));
                MessageBox.Show("Canceled");
                CopyingIsComplete = true;
            },TaskContinuationOptions.OnlyOnCanceled);

            return MaxValue;
        }
        private void Read()
        {
            using (FileStream readStream = new FileStream(pathForCopy, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize, true))
            {
                if (readStream.Length > bufferSize)
                {
                    long currPoss;
                    for (currPoss = 0; currPoss < Math.Truncate((double)readStream.Length / bufferSize); currPoss++)
                    {
                        readStream.Read(buffer, 0, bufferSize);

                        autoResetEvent.Set();
                        autoResetEvent.WaitOne();
                        Progress.Report((int)currPoss);
                        if (token.IsCancellationRequested)
                        {
                            autoResetEvent.Set();
                            token.ThrowIfCancellationRequested();
                            return;
                        } 
                    }
                    if (currPoss * bufferSize < readStream.Length)
                    {
                        buffer = new byte[readStream.Length - currPoss * bufferSize];
                        readStream.Read(buffer, 0, (int)(readStream.Length - currPoss * bufferSize));
                    }
                    Progress.Report((int)currPoss);
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
                    if (token.IsCancellationRequested)
                    {
                        autoResetEvent.Set();
                        token.ThrowIfCancellationRequested();
                        return;
                    } 

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