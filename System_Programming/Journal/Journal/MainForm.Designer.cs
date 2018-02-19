namespace work3
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
            this.btnProceses = new System.Windows.Forms.Button();
            this.btnScrenshots = new System.Windows.Forms.Button();
            this.btnSummarize = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnProceses
            // 
            this.btnProceses.Location = new System.Drawing.Point(114, 32);
            this.btnProceses.Name = "btnProceses";
            this.btnProceses.Size = new System.Drawing.Size(120, 30);
            this.btnProceses.TabIndex = 0;
            this.btnProceses.Text = "Processes";
            this.btnProceses.UseVisualStyleBackColor = true;
            this.btnProceses.Click += new System.EventHandler(this.btnProceses_Click);
            // 
            // btnScrenshots
            // 
            this.btnScrenshots.Location = new System.Drawing.Point(114, 87);
            this.btnScrenshots.Name = "btnScrenshots";
            this.btnScrenshots.Size = new System.Drawing.Size(120, 30);
            this.btnScrenshots.TabIndex = 1;
            this.btnScrenshots.Text = "Screenshots";
            this.btnScrenshots.UseVisualStyleBackColor = true;
            this.btnScrenshots.Click += new System.EventHandler(this.btnScrenshots_Click);
            // 
            // btnSummarize
            // 
            this.btnSummarize.Location = new System.Drawing.Point(114, 142);
            this.btnSummarize.Name = "btnSummarize";
            this.btnSummarize.Size = new System.Drawing.Size(120, 30);
            this.btnSummarize.TabIndex = 2;
            this.btnSummarize.Text = "Summarize";
            this.btnSummarize.UseVisualStyleBackColor = true;
            this.btnSummarize.Click += new System.EventHandler(this.btnSummarize_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 240);
            this.Controls.Add(this.btnSummarize);
            this.Controls.Add(this.btnScrenshots);
            this.Controls.Add(this.btnProceses);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(381, 279);
            this.MinimumSize = new System.Drawing.Size(381, 279);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Journal";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnProceses;
        private System.Windows.Forms.Button btnScrenshots;
        private System.Windows.Forms.Button btnSummarize;
    }
}

