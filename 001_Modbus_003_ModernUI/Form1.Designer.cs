
namespace _001_Modbus_003_ModernUI
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.home_form_load_panel = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker4 = new System.ComponentModel.BackgroundWorker();
            this.home_button = new System.Windows.Forms.Button();
            this.exit_button = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.setting_button = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(43)))), ((int)(((byte)(58)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(145, 520);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // home_form_load_panel
            // 
            this.home_form_load_panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.home_form_load_panel.Location = new System.Drawing.Point(187, 0);
            this.home_form_load_panel.Margin = new System.Windows.Forms.Padding(2);
            this.home_form_load_panel.Name = "home_form_load_panel";
            this.home_form_load_panel.Size = new System.Drawing.Size(916, 515);
            this.home_form_load_panel.TabIndex = 2;
            this.home_form_load_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.home_form_load_panel_Paint);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            // 
            // backgroundWorker3
            // 
            this.backgroundWorker3.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker3_DoWork);
            // 
            // home_button
            // 
            this.home_button.BackColor = System.Drawing.Color.White;
            this.home_button.FlatAppearance.BorderSize = 0;
            this.home_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.home_button.Font = new System.Drawing.Font("Nirmala UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.home_button.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.home_button.Image = ((System.Drawing.Image)(resources.GetObject("home_button.Image")));
            this.home_button.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.home_button.Location = new System.Drawing.Point(2, 2);
            this.home_button.Margin = new System.Windows.Forms.Padding(2);
            this.home_button.Name = "home_button";
            this.home_button.Size = new System.Drawing.Size(139, 50);
            this.home_button.TabIndex = 1;
            this.home_button.Text = "HOME";
            this.home_button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.home_button.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.home_button.UseVisualStyleBackColor = false;
            this.home_button.Click += new System.EventHandler(this.home_button_Click);
            // 
            // exit_button
            // 
            this.exit_button.BackColor = System.Drawing.Color.White;
            this.exit_button.FlatAppearance.BorderSize = 0;
            this.exit_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit_button.Font = new System.Drawing.Font("Nirmala UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit_button.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.exit_button.Image = global::_001_Modbus_003_ModernUI.Properties.Resources.exit;
            this.exit_button.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.exit_button.Location = new System.Drawing.Point(2, 111);
            this.exit_button.Margin = new System.Windows.Forms.Padding(2);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(139, 50);
            this.exit_button.TabIndex = 2;
            this.exit_button.Text = "EXIT";
            this.exit_button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.exit_button.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.exit_button.UseVisualStyleBackColor = false;
            this.exit_button.Click += new System.EventHandler(this.exit_button_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::_001_Modbus_003_ModernUI.Properties.Resources.logo_image;
            this.pictureBox1.InitialImage = global::_001_Modbus_003_ModernUI.Properties.Resources.logo_image;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(143, 115);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // setting_button
            // 
            this.setting_button.BackColor = System.Drawing.Color.White;
            this.setting_button.FlatAppearance.BorderSize = 0;
            this.setting_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setting_button.Font = new System.Drawing.Font("Nirmala UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setting_button.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.setting_button.Image = global::_001_Modbus_003_ModernUI.Properties.Resources.setting;
            this.setting_button.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.setting_button.Location = new System.Drawing.Point(2, 56);
            this.setting_button.Margin = new System.Windows.Forms.Padding(2);
            this.setting_button.Name = "setting_button";
            this.setting_button.Size = new System.Drawing.Size(139, 50);
            this.setting_button.TabIndex = 0;
            this.setting_button.Text = "SETTINGS";
            this.setting_button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.setting_button.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.setting_button.UseVisualStyleBackColor = false;
            this.setting_button.Click += new System.EventHandler(this.setting_button_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.exit_button, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.setting_button, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.home_button, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 353);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33112F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33444F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33445F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(143, 165);
            this.tableLayoutPanel1.TabIndex = 1;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.ClientSize = new System.Drawing.Size(1168, 520);
            this.Controls.Add(this.home_form_load_panel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.program_load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button setting_button;
        private System.Windows.Forms.Button home_button;
        private System.Windows.Forms.Panel home_form_load_panel;
        private System.Windows.Forms.Button exit_button;
        public System.ComponentModel.BackgroundWorker backgroundWorker1;
        public System.ComponentModel.BackgroundWorker backgroundWorker2;
        public System.ComponentModel.BackgroundWorker backgroundWorker3;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.ComponentModel.BackgroundWorker backgroundWorker4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

