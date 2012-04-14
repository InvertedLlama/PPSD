using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PPSDPart2
{
    public partial class frmWorking : Form
    {
        public frmWorking()
        {
            InitializeComponent();
        }

        public void setProgress(int percentage)
        {
            pgbProgress.Value = percentage;            
        }

        public void setProgressStyle(ProgressBarStyle style)
        {
            pgbProgress.Style = style;
        }

        public void setMessage(string message)
        {
            lblMessage.Text = message;
        }
    }
}
