using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;

namespace work3.Classes
{
    public class Logic
    {
        private readonly string PathProcessesFile = Directory.GetCurrentDirectory() + @"\LogProcesses.txt";
        private readonly string PathResultFile = Directory.GetCurrentDirectory() + @"\Result.txt";

        private object locker1 = new object();
        private object locker2 = new object();

        public void StartProcessTimer()
        {
            new Timer(WriteProcesses, 0, 1000, 10000);
        }
        private void WriteProcesses(object Sender)
        {
            lock (locker1)
            {
                using (StreamWriter sw = new StreamWriter(PathProcessesFile, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(Environment.NewLine + DateTime.Now.ToString());

                    Process[] processes = Process.GetProcesses();
                    foreach (Process process in processes)
                    {
                        sw.WriteLine(process.Id + " " + process.ProcessName);
                    }
                }
            }
        }

        public void StartScreenshotsTimer()
        {
            new Timer(SaveScreenshot, 0, 1000, 10000);
        }
        private void SaveScreenshot(object Sender)
        {
            lock (locker2)
            {
                Bitmap screen = new Bitmap(
                System.Windows.Forms.SystemInformation.VirtualScreen.Width,
                System.Windows.Forms.SystemInformation.VirtualScreen.Height);
                Graphics graphics = Graphics.FromImage(screen);
                try
                {
                    graphics.CopyFromScreen(
                            System.Windows.Forms.SystemInformation.VirtualScreen.X,
                            System.Windows.Forms.SystemInformation.VirtualScreen.Y,
                            0, 0, screen.Size);
                    screen.Save(Directory.GetCurrentDirectory() + @"\Screenshot - "
                            + DateTime.Now.ToString().Replace('.', '-').Replace(':', '-') + ".Bmp", ImageFormat.Bmp);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: " + ex);
                }
                finally
                {
                    graphics.Dispose();
                    screen.Dispose();
                }
            }
        }

        public void StartSummarizeTimer()
        {
            new Timer(SaveTotals, 0, 1000, 10000);
        }
        private void SaveTotals(object sender)
        {
            long countLines;
            lock (locker1)
            {
                countLines = File.ReadAllLines(PathProcessesFile).LongLength;
            }

            int countScreenshots;
            lock (locker2)
            {
                countScreenshots = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.bmp").Length;
            }

            using (StreamWriter sw = new StreamWriter(PathResultFile, false, System.Text.Encoding.Default))
            {
                sw.WriteLine("Lines: " + countLines);
                sw.WriteLine("Count of screenshots: " + countScreenshots);
            }


        }
    }
}
