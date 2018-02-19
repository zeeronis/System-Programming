using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using work3.Classes;

namespace work3
{
    public partial class MainForm : Form
    {
        
        public MainForm()
        {
            InitializeComponent();
        }

        Logic logic = new Logic();
        private void btnProceses_Click(object sender, EventArgs e)
        {
            btnProceses.Enabled = false;
            logic.StartProcessTimer();
        }

        private void btnScrenshots_Click(object sender, EventArgs e)
        {
            btnScrenshots.Enabled = false;
            logic.StartScreenshotsTimer();
        }

        private void btnSummarize_Click(object sender, EventArgs e)
        {
            btnSummarize.Enabled = false;
            logic.StartSummarizeTimer();
        }
    }
}
