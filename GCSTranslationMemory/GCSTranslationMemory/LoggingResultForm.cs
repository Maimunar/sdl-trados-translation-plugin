using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCSTranslationMemory
{
    public partial class LoggingResultForm : Form
    {
        public LoggingResultForm(List<string> logs)
        {
            InitializeComponent();
            //lbLogs.DataSource = logs;
            //foreach(string log in logs)
            //{
            //    lbLogs.Items.Add(log);
            //}
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}
