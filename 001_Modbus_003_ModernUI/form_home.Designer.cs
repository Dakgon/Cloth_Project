namespace _001_Modbus_003_ModernUI
{
    partial class form_home
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
            this.data_groupBox = new System.Windows.Forms.GroupBox();
            this.stop_classifier_button = new System.Windows.Forms.Button();
            this.Capture_image = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.picture_groupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.data_groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.picture_groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // data_groupBox
            // 
            this.data_groupBox.Controls.Add(this.tableLayoutPanel1);
            this.data_groupBox.Controls.Add(this.dataGridView1);
            this.data_groupBox.Font = new System.Drawing.Font("Nirmala UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.data_groupBox.Location = new System.Drawing.Point(676, 49);
            this.data_groupBox.Margin = new System.Windows.Forms.Padding(2);
            this.data_groupBox.Name = "data_groupBox";
            this.data_groupBox.Padding = new System.Windows.Forms.Padding(2);
            this.data_groupBox.Size = new System.Drawing.Size(218, 457);
            this.data_groupBox.TabIndex = 9;
            this.data_groupBox.TabStop = false;
            this.data_groupBox.Text = "Predicted Data";
            this.data_groupBox.Enter += new System.EventHandler(this.data_groupBox_Enter);
            // 
            // stop_classifier_button
            // 
            this.stop_classifier_button.Enabled = false;
            this.stop_classifier_button.Font = new System.Drawing.Font("Nirmala UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stop_classifier_button.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.stop_classifier_button.Location = new System.Drawing.Point(2, 52);
            this.stop_classifier_button.Margin = new System.Windows.Forms.Padding(2);
            this.stop_classifier_button.Name = "stop_classifier_button";
            this.stop_classifier_button.Size = new System.Drawing.Size(200, 46);
            this.stop_classifier_button.TabIndex = 2;
            this.stop_classifier_button.Text = "Stop Classifier";
            this.stop_classifier_button.UseVisualStyleBackColor = true;
            this.stop_classifier_button.Click += new System.EventHandler(this.stop_classifier_button_click);
            // 
            // Capture_image
            // 
            this.Capture_image.Enabled = false;
            this.Capture_image.Font = new System.Drawing.Font("Nirmala UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Capture_image.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Capture_image.Location = new System.Drawing.Point(2, 2);
            this.Capture_image.Margin = new System.Windows.Forms.Padding(2);
            this.Capture_image.Name = "Capture_image";
            this.Capture_image.Size = new System.Drawing.Size(200, 46);
            this.Capture_image.TabIndex = 1;
            this.Capture_image.Text = "Capture Image";
            this.Capture_image.UseVisualStyleBackColor = true;
            this.Capture_image.Click += new System.EventHandler(this.Capture_button_click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridView1.Location = new System.Drawing.Point(5, 31);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(208, 293);
            this.dataGridView1.TabIndex = 0;
            // 
            // picture_groupBox
            // 
            this.picture_groupBox.Controls.Add(this.pictureBox);
            this.picture_groupBox.Font = new System.Drawing.Font("Nirmala UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.picture_groupBox.Location = new System.Drawing.Point(12, 49);
            this.picture_groupBox.Margin = new System.Windows.Forms.Padding(2);
            this.picture_groupBox.Name = "picture_groupBox";
            this.picture_groupBox.Padding = new System.Windows.Forms.Padding(2);
            this.picture_groupBox.Size = new System.Drawing.Size(659, 457);
            this.picture_groupBox.TabIndex = 8;
            this.picture_groupBox.TabStop = false;
            this.picture_groupBox.Text = "Stream Image";
            this.picture_groupBox.Enter += new System.EventHandler(this.picture_groupBox_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 32);
            this.label1.TabIndex = 7;
            this.label1.Text = "VISION APP";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Image = global::_001_Modbus_003_ModernUI.Properties.Resources.default_image;
            this.pictureBox.Location = new System.Drawing.Point(34, 31);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(600, 406);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.stop_classifier_button, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Capture_image, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 337);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(208, 100);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // form_home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.ClientSize = new System.Drawing.Size(901, 520);
            this.Controls.Add(this.data_groupBox);
            this.Controls.Add(this.picture_groupBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "form_home";
            this.Text = "form_home";
            this.data_groupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.picture_groupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox data_groupBox;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox picture_groupBox;
        public System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button Capture_image;
        public System.Windows.Forms.Button stop_classifier_button;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}