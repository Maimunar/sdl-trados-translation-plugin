using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GCSTranslationMemory
{
    ///<summary>
    /// A Windows form that displays the provided list of reference numbers and error logs
    /// </summary>
    public partial class ReferenceNumbersForm : Form
    {
        public ReferenceNumbersForm(List<string> refNumbers, List<LogUnit> errors)
        {
            InitializeComponent();

            foreach (string refNumber in refNumbers) rtbRefNumbers.Text += $"{refNumber}\n";

            if (errors.Count() == 0)
            {
                // Hides the error grid panel if the error count is 0
                this.MinimumSize = new Size(this.Width, 250);
                this.MaximumSize = new Size(this.Width, 250);
            }
            else errorDataGrid.DataSource = errors;
        }
    }
}
