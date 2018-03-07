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
            progress = new Progress<int>(percent => pbCopying.Value += percent);
            copying = new Copying(progress);
        }

        private Progress<int> progress;
        private Copying copying;
        private void BtnStartCopy_Click(object sender, EventArgs e)
        {
            if (copying.CopyingIsComplete == true)
            {
                if (Directory.Exists(TbPathPaste.Text))
                {
                    if (TbPathCopy.Lines.Length == 1 && Directory.Exists(TbPathCopy.Lines[0]))
                    {
                        pbCopying.Value = 0;
                        copying.CopyDirrectry(TbPathCopy.Lines[0], TbPathPaste.Text);
                    }
                    else
                    {
                        pbCopying.Value = 0;
                        pbCopying.Maximum = (int)copying.StartCopying(TbPathCopy.Lines, TbPathPaste.Text);
                    }
                }
                else
                {
                    MessageBox.Show("path or file don't found");
                }
            }
        }

        private void BtnFileCopy_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string[] filesPaths = openFileDialog.FileNames;
                    if (filesPaths.Length <= 5)
                    {
                        TbPathCopy.Lines = openFileDialog.FileNames;
                    }
                    else
                    {
                        MessageBox.Show("Maximum number of selected files: 5");
                    }
                }
            }
        }
        private void BtnFolderCopy_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                     TbPathCopy.Text = folderBrowserDialog.SelectedPath;
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
