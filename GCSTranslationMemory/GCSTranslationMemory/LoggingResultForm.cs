using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GCSTranslationMemory
{
    public partial class LoggingResultForm : Form
    {
        public LoggingResultForm(List<string> logs)
        {
            InitializeComponent();
            lbLogs.DataSource = logs;
        }

        private void btnClose_Click(object sender, EventArgs e) { this.Close(); }
    }
}
