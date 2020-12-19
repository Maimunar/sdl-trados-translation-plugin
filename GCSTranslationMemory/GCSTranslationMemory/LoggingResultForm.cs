using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GCSTranslationMemory
{
    public partial class LoggingResultForm : Form
    {
        ///<summary>
        /// A Windows form that displays the provided list of logs
        /// </summary>
        public LoggingResultForm(List<LogUnit> logs)
        {
            InitializeComponent();
            logsDataGrid.DataSource = logs;
        }

        /// <summary>
        /// An On-Click button event that closes the form
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e) { this.Close(); }
    }
}
