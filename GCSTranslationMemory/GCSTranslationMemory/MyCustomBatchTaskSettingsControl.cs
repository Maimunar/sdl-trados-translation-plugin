using Sdl.Desktop.IntegrationApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCSTranslationMemory
{
    class MyCustomBatchTaskSettingsControl : UserControl, ISettingsAware<MyCustomBatchTaskSettings>
    {
        private GroupBox groupBox1;
        private Button btnRestoreDefaults;
        private Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;

        // Member that refers to the batch task settings
        public MyCustomBatchTaskSettings Settings { get; set; }

        // Initializes the UI component
        public MyCustomBatchTaskSettingsControl()
        {
            InitializeComponent();
        }
        public void SetSettings(MyCustomBatchTaskSettings taskSettings)
        {
            // sets the UI element, i.e. the status dropdown list to the corresponding segment status value
            Settings = taskSettings;
            UpdateUI(taskSettings);
        }
        public void UpdateSettings(MyCustomBatchTaskSettings mySettings)
        {
            Settings = mySettings;
        }

        // Updates the UI elements to the corresponding settings
        public void UpdateUI(MyCustomBatchTaskSettings mySettings)
        {
            Settings = mySettings;
            this.UpdateSettings(Settings);
        }
        // The control elements on the UI are configured with the corresponding values
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.SetSettings(Settings);
        }


        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRestoreDefaults = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(370, 240);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // btnRestoreDefaults
            // 
            this.btnRestoreDefaults.Location = new System.Drawing.Point(12, 276);
            this.btnRestoreDefaults.Name = "btnRestoreDefaults";
            this.btnRestoreDefaults.Size = new System.Drawing.Size(127, 23);
            this.btnRestoreDefaults.TabIndex = 2;
            this.btnRestoreDefaults.Text = "Restore Defaults";
            this.btnRestoreDefaults.UseVisualStyleBackColor = true;
            this.btnRestoreDefaults.Click += new System.EventHandler(this.btnRestoreDefaults_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label1.Location = new System.Drawing.Point(101, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Template Settings Page";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MyCustomBatchTaskSettingsControl
            // 
            this.Controls.Add(this.btnRestoreDefaults);
            this.Controls.Add(this.groupBox1);
            this.Name = "MyCustomBatchTaskSettingsControl";
            this.Size = new System.Drawing.Size(378, 302);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        private void btnRestoreDefaults_Click(object sender, EventArgs e)
        {
            Settings.ResetToDefaults();
            this.UpdateUI(Settings);
        }

    }
}
