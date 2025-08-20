using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using EasyModbus;
using System.IO;
using _001_Modbus_003_ModernUI.Properties;
using System.Threading;



namespace _001_Modbus_003_ModernUI
{
    public partial class form_setting : Form
    {
        private Form1 mainForm;
        public form_setting(Form1 mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void connect_button_click(object sender, EventArgs e)
        {
       
        }

        private void script_browser_button_click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                mainForm.python_script_path = openFileDialog1.FileName;
                mainForm.script_is_open = true;

                string folder_path = Path.GetDirectoryName(mainForm.python_script_path);
                if (Directory.Exists(Path.Combine(folder_path, ".venv")))
                {
                    if (Directory.Exists(Path.Combine(folder_path, ".venv", "Scripts")))
                    {
                        if (File.Exists(Path.Combine(folder_path, ".venv", "Scripts", "python.exe")))
                        {
                            MessageBox.Show(this, "Opened Python interpreter sucessfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            mainForm.python_path = Path.Combine(folder_path, ".venv", "Scripts", "python.exe");
                            mainForm.script_is_open = true;
                        }
                        else
                        {
                            MessageBox.Show(this, "Failed to open Python interpreter\nPython interperter could not be found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            mainForm.script_is_open = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Failed to open Python interpreter\nScripts path does not exist", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        mainForm.script_is_open = false;
                    }
                }
                else
                {
                    MessageBox.Show(this, "Failed to open Python interpreter\nVenv path does not exist", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    mainForm.script_is_open = false;
                }

            }
            else
            {
                MessageBox.Show(this, "Failed to Open Python script", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                mainForm.script_is_open = false;
            }

            if (mainForm.script_is_open && mainForm.image_is_open)
            {
                run_classifier_button.Enabled = true;
                run_classifier_button.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;

                mainForm.backgroundWorker2.RunWorkerAsync();
            }
            else
            {
                run_classifier_button.Enabled = false;
                run_classifier_button.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            }
        }

        private void open_image_folder_click(object sender, EventArgs e)
        {
            DialogResult dr = folderBrowserDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                mainForm.image_path = folderBrowserDialog1.SelectedPath;
                mainForm.image_path += "/";
                mainForm.directory = new DirectoryInfo(mainForm.image_path);
                mainForm.image_is_open = true;
            }
            else
            {
                MessageBox.Show(this, "Failed to Open Image path", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                mainForm.image_is_open = false;
            }

            if (mainForm.script_is_open && mainForm.image_is_open)
            {
                run_classifier_button.Enabled = true;
                run_classifier_button.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
                mainForm.backgroundWorker2.RunWorkerAsync();
            }
            else
            {
                run_classifier_button.Enabled = false;
                run_classifier_button.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            }
        }

        private void camera_connect_button_click(object sender, EventArgs e)
        {
            mainForm.camera = new BaslerCamera();
            string message = mainForm.camera.camera_init();

            if (message == "Camera is successfully connected")
            {
                mainForm.camera_is_open = true;

                if (!mainForm.backgroundWorker1.IsBusy)
                {
                    mainForm.backgroundWorker1.RunWorkerAsync();
                }
                if (!mainForm.backgroundWorker4.IsBusy)
                {
                    mainForm.backgroundWorker4.RunWorkerAsync();
                    MessageBox.Show("BackgroundWorker4 started");
                }
            }
            else
            {
                mainForm.camera_is_open = false;
            }
            MessageBox.Show(this, message, "Camera Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        

        private void run_classifier_button_click(object sender, EventArgs e)
        {
            mainForm.form_home_instance.stop_classifier_button.Enabled = true;
            mainForm.form_home_instance.stop_classifier_button.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            mainForm.form_home_instance.Capture_image.Enabled = true;
            mainForm.start_python_script(mainForm.python_script_path);

            // mainForm.backgroundWorker3.RunWorkerAsync();
        }

        private void com_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
