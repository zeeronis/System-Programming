using Copying_files.Classes;
using System;
using System.IO;
using System.Windows.Forms;

namespace Copying_files
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            progress = new Progress<int>(percent => pbCopying.Value = percent);
            copying = new Copying(progress);
        }

        private Progress<int> progress;
        private Copying copying;
        private void BtnStartCopy_Click(object sender, EventArgs e)
        {
            if (copying.CopyingIsComplete == true)
            {
                if (File.Exists(TbPathCopy.Text) == true && Directory.Exists(TbPathPaste.Text))
                {
                    pbCopying.Value = 0;
                    pbCopying.Maximum = copying.StartCopying(TbPathCopy.Text, TbPathPaste.Text);
                }
                else
                {
                    MessageBox.Show("path or file don't found");
                }
            }
            
        }

        private void UpdatePB(int MinValue, int MaxValue)
        {
            pbCopying.Value = MinValue;
            pbCopying.Maximum = MaxValue;
        }

        private void BtnFileCopy_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    TbPathCopy.Text = openFileDialog.FileName;
                }
            }
        }
        private void BtnFilePaste_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    TbPathPaste.Text = folderBrowserDialog.SelectedPath + @"\";
                }
            }
                
            
        }

        private void BntCancel_Click(object sender, EventArgs e)
        {
            if (copying.CopyingIsComplete == false)
            {
                copying.CancelCopy();
            }
        }
    }
}
