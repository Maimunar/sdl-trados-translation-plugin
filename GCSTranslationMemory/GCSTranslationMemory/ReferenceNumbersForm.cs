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
    public partial class ReferenceNumbersForm : Form
    {
        public ReferenceNumbersForm(List<string> refNumbers, List<LogUnit> errors)
        {
            InitializeComponent();

            foreach (string refNumber in refNumbers) rtbRefNumbers.Text += $"{refNumber}\n";

            //if (errors.Count() == 0) this.Height = 250;
            //else errorDataGrid.DataSource = errors;
            this.Height = 250;
            errorDataGrid.DataSource = errors;
        }
    }
}
