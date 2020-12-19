
namespace GCSTranslationMemory
{
    partial class ReferenceNumbersForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblRefNumbers = new System.Windows.Forms.Label();
            this.rtbRefNumbers = new System.Windows.Forms.RichTextBox();
            this.lblErrorList = new System.Windows.Forms.Label();
            this.errorDataGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.errorDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRefNumbers
            // 
            this.lblRefNumbers.AutoSize = true;
            this.lblRefNumbers.Location = new System.Drawing.Point(12, 9);
            this.lblRefNumbers.Name = "lblRefNumbers";
            this.lblRefNumbers.Size = new System.Drawing.Size(138, 13);
            this.lblRefNumbers.TabIndex = 0;
            this.lblRefNumbers.Text = "Found Reference Numbers:";
            // 
            // rtbRefNumbers
            // 
            this.rtbRefNumbers.BackColor = System.Drawing.SystemColors.Window;
            this.rtbRefNumbers.Location = new System.Drawing.Point(15, 25);
            this.rtbRefNumbers.Name = "rtbRefNumbers";
            this.rtbRefNumbers.ReadOnly = true;
            this.rtbRefNumbers.Size = new System.Drawing.Size(333, 176);
            this.rtbRefNumbers.TabIndex = 1;
            this.rtbRefNumbers.Text = "";
            // 
            // lblErrorList
            // 
            this.lblErrorList.AutoSize = true;
            this.lblErrorList.Location = new System.Drawing.Point(12, 215);
            this.lblErrorList.Name = "lblErrorList";
            this.lblErrorList.Size = new System.Drawing.Size(51, 13);
            this.lblErrorList.TabIndex = 2;
            this.lblErrorList.Text = "Error List:";
            // 
            // errorDataGrid
            // 
            this.errorDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.errorDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.errorDataGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.errorDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.errorDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.errorDataGrid.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.errorDataGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.errorDataGrid.Location = new System.Drawing.Point(12, 231);
            this.errorDataGrid.Name = "errorDataGrid";
            this.errorDataGrid.ReadOnly = true;
            this.errorDataGrid.RowHeadersVisible = false;
            this.errorDataGrid.Size = new System.Drawing.Size(336, 188);
            this.errorDataGrid.TabIndex = 3;
            // 
            // ReferenceNumbersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 431);
            this.Controls.Add(this.errorDataGrid);
            this.Controls.Add(this.lblErrorList);
            this.Controls.Add(this.rtbRefNumbers);
            this.Controls.Add(this.lblRefNumbers);
            this.MaximumSize = new System.Drawing.Size(380, 470);
            this.MinimumSize = new System.Drawing.Size(380, 470);
            this.Name = "ReferenceNumbersForm";
            this.Text = "Batch Task Results";
            ((System.ComponentModel.ISupportInitialize)(this.errorDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRefNumbers;
        private System.Windows.Forms.RichTextBox rtbRefNumbers;
        private System.Windows.Forms.Label lblErrorList;
        private System.Windows.Forms.DataGridView errorDataGrid;
    }
}