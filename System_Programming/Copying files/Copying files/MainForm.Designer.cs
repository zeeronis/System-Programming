namespace Copying_files
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbCopying = new System.Windows.Forms.ProgressBar();
            this.TbPathPaste = new System.Windows.Forms.TextBox();
            this.BtnFilePaste = new System.Windows.Forms.Button();
            this.BtnFileCopy = new System.Windows.Forms.Button();
            this.TbPathCopy = new System.Windows.Forms.TextBox();
            this.BtnStartCopy = new System.Windows.Forms.Button();
            this.BntCancel = new System.Windows.Forms.Button();
            this.BtnFolderCopy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pbCopying
            // 
            this.pbCopying.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbCopying.Location = new System.Drawing.Point(12, 202);
            this.pbCopying.MarqueeAnimationSpeed = 0;
            this.pbCopying.Name = "pbCopying";
            this.pbCopying.Size = new System.Drawing.Size(415, 23);
            this.pbCopying.Step = 0;
            this.pbCopying.TabIndex = 0;
            // 
            // TbPathPaste
            // 
            this.TbPathPaste.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TbPathPaste.Location = new System.Drawing.Point(12, 116);
            this.TbPathPaste.Name = "TbPathPaste";
            this.TbPathPaste.Size = new System.Drawing.Size(313, 22);
            this.TbPathPaste.TabIndex = 1;
            // 
            // BtnFilePaste
            // 
            this.BtnFilePaste.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnFilePaste.Location = new System.Drawing.Point(331, 115);
            this.BtnFilePaste.Name = "BtnFilePaste";
            this.BtnFilePaste.Size = new System.Drawing.Size(96, 23);
            this.BtnFilePaste.TabIndex = 2;
            this.BtnFilePaste.Text = "browse...";
            this.BtnFilePaste.UseVisualStyleBackColor = true;
            this.BtnFilePaste.Click += new System.EventHandler(this.BtnFilePaste_Click);
            // 
            // BtnFileCopy
            // 
            this.BtnFileCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnFileCopy.Location = new System.Drawing.Point(330, 17);
            this.BtnFileCopy.Name = "BtnFileCopy";
            this.BtnFileCopy.Size = new System.Drawing.Size(97, 23);
            this.BtnFileCopy.TabIndex = 4;
            this.BtnFileCopy.Text = "browse files";
            this.BtnFileCopy.UseVisualStyleBackColor = true;
            this.BtnFileCopy.Click += new System.EventHandler(this.BtnFileCopy_Click);
            // 
            // TbPathCopy
            // 
            this.TbPathCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TbPathCopy.Location = new System.Drawing.Point(12, 17);
            this.TbPathCopy.Multiline = true;
            this.TbPathCopy.Name = "TbPathCopy";
            this.TbPathCopy.Size = new System.Drawing.Size(312, 93);
            this.TbPathCopy.TabIndex = 3;
            // 
            // BtnStartCopy
            // 
            this.BtnStartCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnStartCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnStartCopy.Location = new System.Drawing.Point(109, 166);
            this.BtnStartCopy.Name = "BtnStartCopy";
            this.BtnStartCopy.Size = new System.Drawing.Size(105, 30);
            this.BtnStartCopy.TabIndex = 5;
            this.BtnStartCopy.Text = "Copy";
            this.BtnStartCopy.UseVisualStyleBackColor = true;
            this.BtnStartCopy.Click += new System.EventHandler(this.BtnStartCopy_Click);
            // 
            // BntCancel
            // 
            this.BntCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BntCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BntCancel.Location = new System.Drawing.Point(220, 166);
            this.BntCancel.Name = "BntCancel";
            this.BntCancel.Size = new System.Drawing.Size(105, 30);
            this.BntCancel.TabIndex = 6;
            this.BntCancel.Text = "Cancel";
            this.BntCancel.UseVisualStyleBackColor = true;
            this.BntCancel.Click += new System.EventHandler(this.BntCancel_Click);
            // 
            // BtnFolderCopy
            // 
            this.BtnFolderCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnFolderCopy.Location = new System.Drawing.Point(330, 46);
            this.BtnFolderCopy.Name = "BtnFolderCopy";
            this.BtnFolderCopy.Size = new System.Drawing.Size(97, 23);
            this.BtnFolderCopy.TabIndex = 7;
            this.BtnFolderCopy.Text = "browse folder";
            this.BtnFolderCopy.UseVisualStyleBackColor = true;
            this.BtnFolderCopy.Click += new System.EventHandler(this.BtnFolderCopy_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 237);
            this.Controls.Add(this.BtnFolderCopy);
            this.Controls.Add(this.BntCancel);
            this.Controls.Add(this.BtnStartCopy);
            this.Controls.Add(this.BtnFileCopy);
            this.Controls.Add(this.TbPathCopy);
            this.Controls.Add(this.BtnFilePaste);
            this.Controls.Add(this.TbPathPaste);
            this.Controls.Add(this.pbCopying);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbCopying;
        private System.Windows.Forms.TextBox TbPathPaste;
        private System.Windows.Forms.Button BtnFilePaste;
        private System.Windows.Forms.Button BtnFileCopy;
        private System.Windows.Forms.TextBox TbPathCopy;
        private System.Windows.Forms.Button BtnStartCopy;
        private System.Windows.Forms.Button BntCancel;
        private System.Windows.Forms.Button BtnFolderCopy;
    }
}