using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace work3.Classes
{
    public class Logic
    {
        private readonly string PathProcessesFile = Directory.GetCurrentDirectory() + @"\LogProcesses.txt";
        private readonly string PathResultFile = Directory.GetCurrentDirectory() + @"\Result.txt";

        public void StartProcessTimer()
        {
            Timer timer = new Timer();
            timer.Interval = 10000;
            timer.Tick += new EventHandler(WriteProcesses);
            timer.Enabled = true;
        }
        private void WriteProcesses(object Sender, EventArgs e)
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

        public void StartScreenshotsTimer()
        {
            Timer timer = new Timer();
            timer.Interval = 10000;
            timer.Tick += new EventHandler(SaveScreenshot);
            timer.Enabled = true;
        }
        private void SaveScreenshot(object Sender, EventArgs e)
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

        public void StartSummarizeTimer()
        {
            Timer timer = new Timer();
            timer.Interval = 10000;
            timer.Tick += new EventHandler(SaveTotals);
            timer.Enabled = true;
        }

        private void SaveTotals(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(PathResultFile, false, System.Text.Encoding.Default))
            {
                sw.WriteLine("Lines: " + File.ReadAllLines(PathProcessesFile).LongLength);
                sw.WriteLine("Count of screenshots: " 
                    + Directory.GetFiles(Directory.GetCurrentDirectory(),"*.bmp").Length);
            }

        }
    }
}
