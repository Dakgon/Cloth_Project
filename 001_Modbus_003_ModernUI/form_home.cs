using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyModbus;

namespace _001_Modbus_003_ModernUI
{
    public partial class form_home : Form
    {
        private Form1 mainForm;
        public form_home(Form1 mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void stop_classifier_button_click(object sender, EventArgs e)
        {
            stop_classifier_button.Enabled = false;
            stop_classifier_button.ForeColor = System.Drawing.SystemColors.ButtonShadow;
        }

        private void Capture_button_click(object sender, EventArgs e)
        {
            try
            {
                Capture_image.Enabled = true;
                //Capture_image.ForeColor = System.Drawing.SystemColors.
                mainForm.condition_sastified = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Failed to disconnect Modbus Client\nError: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        private void pictureBox_Click(object sender, EventArgs e)
        {
            // Không cần làm gì nếu chưa muốn
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void picture_groupBox_Enter(object sender, EventArgs e)
        {

        }

        private void data_groupBox_Enter(object sender, EventArgs e)
        {

        }
    }
}
