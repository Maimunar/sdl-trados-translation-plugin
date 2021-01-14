using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCSTranslationMemory.Forms
{
    // Feedback form dialog used for creation and sending of feedback via email
    public partial class FeedbackForm : Form
    {
        OpenFileDialog attachmentsFileDialog;
        BindingList<String> attachmentFilePaths;

        //Mailing Variables
        const string SMTP_HOST = "smtp.gmail.com";
        const int SMTP_PORT = 587;

        // In order to succesfully do that, please use a gmail account or setup your own SMTP service
        // In order to be able to send emails via Gmail, allow Less secure app access (not recommended on personal emails, use a dedicated email for this service from your account settings!
        // For more information, check here: https://blog.elmah.io/how-to-send-emails-from-csharp-net-the-definitive-tutorial/

        // Email and Password of the service - these can be changed to a service of your choosing.
        const string SENDER_EMAIL = "mk3planner@gmail.com";
        const string SENDER_PASSWORD = "drM6bZuKxu85eQ";

        // The receiver's email - this can be changed freely and dictates which email the feedback will be sent to
        const string RECEIVER_EMAIL = "burnermail123@mail.bg";

        public FeedbackForm()
        {
            InitializeComponent();
            // Initial form setup
            attachmentFilePaths = new BindingList<string>();
            lbAttachments.DataSource = attachmentFilePaths;
            cmbUrgency.SelectedIndex = 0;
            attachmentsFileDialog = new OpenFileDialog
            {
                Title = "Select attachments",
                RestoreDirectory = true,
                CheckFileExists = true,
                CheckPathExists = true,
                Multiselect = true
            };
        }

        
        private void btnSend_Click(object sender, EventArgs e)
        {
            // Requires a summary in order to work
            if(tbTitle.TextLength > 0)
            {
                string subject = tbTitle.Text;
                DateTime time = DateTime.Now;
                // The mail's body - contains the current time, the feedback's urgency as well as the problem description
                string body = $"<h3>Sent by GCS Trados Studio Plugin on {time}</h3>";
                body += $"<p>Urgency of the issue: {cmbUrgency.SelectedItem}</p>";
                body += $"<p>{rtbDescription.Text.Replace("\n", "<br>")}</p>";
                
                // Smtp simple setup
                var smtpClient = new SmtpClient(SMTP_HOST)
                {
                    Port = SMTP_PORT,
                    Credentials = new NetworkCredential(SENDER_EMAIL, SENDER_PASSWORD),
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(SENDER_EMAIL),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true,
                };
                mailMessage.To.Add(RECEIVER_EMAIL);

                // Attachment logic
                foreach (String filePath in attachmentFilePaths)
                {
                    Attachment attachment = new Attachment(filePath);
                    mailMessage.Attachments.Add(attachment);
                }

                smtpClient.Send(mailMessage);

                MessageBox.Show("Feedback sucessfully sent!");
                this.Close();
            }
            else MessageBox.Show("You can't send feedback without a subject.");
        }

        // Closes the feedback form and cancels the process
        private void btnCancel_Click(object sender, EventArgs e) => this.Close();

        // Adds the selected attachments. As a result, these files will be flagged to be send as part of the feedback
        private void btnAddAttachment_Click(object sender, EventArgs e)
        {
            // Shows the file dialog window to select the needed files.
            DialogResult dr = this.attachmentsFileDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                foreach (String fileName in attachmentsFileDialog.FileNames)
                {
                    long fileSize = new FileInfo(fileName).Length;

                    // If the file size exceeeds 10 megabytes, a warning window will show up and that file will not be added to the attachments list
                    // The file's size is calculated in bytes. (e.g 10485760 bytes = 10 megabytes)
                    if (fileSize <= 10485760) attachmentFilePaths.Add(fileName);
                    else MessageBox.Show("The size of the selected file exceeds the 10 MB limit.");
                }
            }
        }

        // Removes the selected attachment. As a result, these files will be unflagged and will not be send with the feedback form
        private void btnRemoveAttachment_Click(object sender, EventArgs e)
        {
            if(lbAttachments.SelectedIndex != -1 && lbAttachments.SelectedIndex < attachmentFilePaths.Count)
            {
                attachmentFilePaths.RemoveAt(lbAttachments.SelectedIndex);
            }
        }
    }
}
