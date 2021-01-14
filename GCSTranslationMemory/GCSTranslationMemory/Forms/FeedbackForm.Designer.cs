
namespace GCSTranslationMemory.Forms
{
    partial class FeedbackForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.cmbUrgency = new System.Windows.Forms.ComboBox();
            this.lblUrgency = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.lblAttachments = new System.Windows.Forms.Label();
            this.lbAttachments = new System.Windows.Forms.ListBox();
            this.btnAddAttachment = new System.Windows.Forms.Button();
            this.btnRemoveAttachment = new System.Windows.Forms.Button();
            this.lblFeedbackInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(4, 43);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(79, 13);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Title (Summary)";
            // 
            // rtbDescription
            // 
            this.rtbDescription.Location = new System.Drawing.Point(89, 77);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new System.Drawing.Size(392, 143);
            this.rtbDescription.TabIndex = 1;
            this.rtbDescription.Text = "";
            // 
            // tbTitle
            // 
            this.tbTitle.Location = new System.Drawing.Point(89, 40);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(392, 20);
            this.tbTitle.TabIndex = 2;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(23, 80);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "Description";
            // 
            // cmbUrgency
            // 
            this.cmbUrgency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUrgency.FormattingEnabled = true;
            this.cmbUrgency.Items.AddRange(new object[] {
            "Low",
            "Medium",
            "High"});
            this.cmbUrgency.Location = new System.Drawing.Point(89, 235);
            this.cmbUrgency.Name = "cmbUrgency";
            this.cmbUrgency.Size = new System.Drawing.Size(152, 21);
            this.cmbUrgency.TabIndex = 4;
            // 
            // lblUrgency
            // 
            this.lblUrgency.AutoSize = true;
            this.lblUrgency.Location = new System.Drawing.Point(36, 235);
            this.lblUrgency.Name = "lblUrgency";
            this.lblUrgency.Size = new System.Drawing.Size(47, 13);
            this.lblUrgency.TabIndex = 5;
            this.lblUrgency.Text = "Urgency";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(207, 401);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(134, 37);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(347, 402);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(134, 36);
            this.btnSend.TabIndex = 7;
            this.btnSend.Text = "Submit Feedback";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lblAttachments
            // 
            this.lblAttachments.AutoSize = true;
            this.lblAttachments.Location = new System.Drawing.Point(17, 275);
            this.lblAttachments.Name = "lblAttachments";
            this.lblAttachments.Size = new System.Drawing.Size(66, 13);
            this.lblAttachments.TabIndex = 8;
            this.lblAttachments.Text = "Attachments";
            // 
            // lbAttachments
            // 
            this.lbAttachments.FormattingEnabled = true;
            this.lbAttachments.Location = new System.Drawing.Point(89, 275);
            this.lbAttachments.Name = "lbAttachments";
            this.lbAttachments.Size = new System.Drawing.Size(392, 108);
            this.lbAttachments.TabIndex = 9;
            // 
            // btnAddAttachment
            // 
            this.btnAddAttachment.Location = new System.Drawing.Point(20, 315);
            this.btnAddAttachment.Name = "btnAddAttachment";
            this.btnAddAttachment.Size = new System.Drawing.Size(63, 31);
            this.btnAddAttachment.TabIndex = 10;
            this.btnAddAttachment.Text = "Add";
            this.btnAddAttachment.UseVisualStyleBackColor = true;
            this.btnAddAttachment.Click += new System.EventHandler(this.btnAddAttachment_Click);
            // 
            // btnRemoveAttachment
            // 
            this.btnRemoveAttachment.Location = new System.Drawing.Point(20, 352);
            this.btnRemoveAttachment.Name = "btnRemoveAttachment";
            this.btnRemoveAttachment.Size = new System.Drawing.Size(63, 31);
            this.btnRemoveAttachment.TabIndex = 11;
            this.btnRemoveAttachment.Text = "Remove";
            this.btnRemoveAttachment.UseVisualStyleBackColor = true;
            this.btnRemoveAttachment.Click += new System.EventHandler(this.btnRemoveAttachment_Click);
            // 
            // lblFeedbackInfo
            // 
            this.lblFeedbackInfo.AutoSize = true;
            this.lblFeedbackInfo.Location = new System.Drawing.Point(4, 9);
            this.lblFeedbackInfo.Name = "lblFeedbackInfo";
            this.lblFeedbackInfo.Size = new System.Drawing.Size(240, 13);
            this.lblFeedbackInfo.TabIndex = 12;
            this.lblFeedbackInfo.Text = "Please describe your issue in the following format:";
            // 
            // FeedbackForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 452);
            this.Controls.Add(this.lblFeedbackInfo);
            this.Controls.Add(this.btnRemoveAttachment);
            this.Controls.Add(this.btnAddAttachment);
            this.Controls.Add(this.lbAttachments);
            this.Controls.Add(this.lblAttachments);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblUrgency);
            this.Controls.Add(this.cmbUrgency);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.tbTitle);
            this.Controls.Add(this.rtbDescription);
            this.Controls.Add(this.lblTitle);
            this.Name = "FeedbackForm";
            this.Text = "Submit feedback to GCS";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.RichTextBox rtbDescription;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.ComboBox cmbUrgency;
        private System.Windows.Forms.Label lblUrgency;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lblAttachments;
        private System.Windows.Forms.ListBox lbAttachments;
        private System.Windows.Forms.Button btnAddAttachment;
        private System.Windows.Forms.Button btnRemoveAttachment;
        private System.Windows.Forms.Label lblFeedbackInfo;
    }
}