using System;
using System.Windows.Forms;

namespace GCSTranslationMemory
{
    public partial class LoggingResultForm : Form
    {
        public LoggingResultForm()
        {
            InitializeComponent();

            MessageBox.Show("Results form initialized");
            //lbLogs.DataSource = logs;
            //foreach(string log in logs)
            //{
            //    lbLogs.Items.Add(log);
            //}
        }

        private void btnClose_Click(object sender, EventArgs e) { this.Close(); }
    }
}
