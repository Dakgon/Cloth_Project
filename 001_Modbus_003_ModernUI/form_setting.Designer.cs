namespace _001_Modbus_003_ModernUI
{
    partial class form_setting
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.run_classifier_button = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.camera_connect_button = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Settings";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.run_classifier_button);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Font = new System.Drawing.Font("Nirmala UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(45, 72);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(194, 210);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "File and Image Brower";
            // 
            // run_classifier_button
            // 
            this.run_classifier_button.Enabled = false;
            this.run_classifier_button.Font = new System.Drawing.Font("Nirmala UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.run_classifier_button.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.run_classifier_button.Location = new System.Drawing.Point(136, 181);
            this.run_classifier_button.Margin = new System.Windows.Forms.Padding(2);
            this.run_classifier_button.Name = "run_classifier_button";
            this.run_classifier_button.Size = new System.Drawing.Size(52, 24);
            this.run_classifier_button.TabIndex = 4;
            this.run_classifier_button.Text = "Apply";
            this.run_classifier_button.UseVisualStyleBackColor = true;
            this.run_classifier_button.Click += new System.EventHandler(this.run_classifier_button_click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(4, 124);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(184, 32);
            this.button2.TabIndex = 0;
            this.button2.Text = "Image Directory browser";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.open_image_folder_click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(4, 61);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(184, 32);
            this.button1.TabIndex = 0;
            this.button1.Text = "Script browser";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.script_browser_button_click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.camera_connect_button);
            this.groupBox3.Font = new System.Drawing.Font("Nirmala UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(45, 287);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(194, 126);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Camera";
            // 
            // camera_connect_button
            // 
            this.camera_connect_button.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.camera_connect_button.Location = new System.Drawing.Point(4, 58);
            this.camera_connect_button.Margin = new System.Windows.Forms.Padding(2);
            this.camera_connect_button.Name = "camera_connect_button";
            this.camera_connect_button.Size = new System.Drawing.Size(184, 32);
            this.camera_connect_button.TabIndex = 1;
            this.camera_connect_button.Text = "Connect to Camera";
            this.camera_connect_button.UseVisualStyleBackColor = true;
            this.camera_connect_button.Click += new System.EventHandler(this.camera_connect_button_click);
            // 
            // form_setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.ClientSize = new System.Drawing.Size(621, 482);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "form_setting";
            this.Text = "form_setting";
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button button2;
        public System.Windows.Forms.Button run_classifier_button;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.Button camera_connect_button;
    }
}