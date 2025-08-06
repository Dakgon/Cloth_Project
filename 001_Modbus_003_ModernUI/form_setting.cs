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


        /// <summary>
        /// This function populates available BaudRate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void baud_comboBox_click(object sender, EventArgs e)
        {
            baud_comboBox.Items.Clear();
            string[] baudrate = { "9600", "19200", "38400", "57600", "115200" };
            baud_comboBox.Items.AddRange(baudrate);
            if (baud_comboBox.Items.Count > 1)
            {
                baud_comboBox.SelectedItem = baud_comboBox.Items[0];
            }
        }


        /// <summary>
        /// This function populates available COM ports
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void com_comboBox_click(object sender, EventArgs e)
        {
            com_comboBox.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            com_comboBox.Items.AddRange(ports);
            if (com_comboBox.Items.Count > 1)
            {
                com_comboBox.SelectedItem = ports[0];
            }
        }

        private void connect_button_click(object sender, EventArgs e)
        {
            if (com_comboBox.SelectedItem != null && baud_comboBox.SelectedItem != null)
            {
                mainForm.modbus_client = new ModbusClient(com_comboBox.SelectedItem.ToString());
                mainForm.modbus_client.UnitIdentifier = 1;
                mainForm.modbus_client.Baudrate = int.Parse(baud_comboBox.SelectedItem.ToString());
                mainForm.modbus_client.Parity = System.IO.Ports.Parity.None;
                mainForm.modbus_client.StopBits = System.IO.Ports.StopBits.One;
                mainForm.modbus_client.ConnectionTimeout = 500;
                mainForm.modbus_client.NumberOfRetries = 1;

                try
                {
                    this.Enabled = false;
                    this.ForeColor = System.Drawing.SystemColors.ButtonShadow;
                    mainForm.modbus_client.Connect();
                    this.Enabled = true;
                    this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;

                    if (mainForm.modbus_client.Connected)
                    {
                        MessageBox.Show(this, "Modbus Client successfully connected", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        mainForm.form_home_instance.stop_button.Enabled = true;
                        mainForm.form_home_instance.stop_button.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
                        mainForm.backgroundWorker1.RunWorkerAsync();
                    }
                    else
                    {
                        MessageBox.Show(this, "Modbus connection failed after retries", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Could not connect to Modbus Client \n" + "Error Code: " + (string)ex.Message + "\nPlease select another ModBus configuration", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    mainForm.form_home_instance.stop_button.Enabled = false;
                    mainForm.form_home_instance.stop_button.ForeColor = System.Drawing.SystemColors.ButtonShadow;
                    this.Enabled = true;
                    this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
                    return;
                }
            }
            else if (com_comboBox.SelectedItem == null)
            {
                MessageBox.Show(this, "COM port undefined", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                mainForm.form_home_instance.stop_button.Enabled = false;
                mainForm.form_home_instance.stop_button.ForeColor = System.Drawing.SystemColors.ButtonShadow;
                return;
            }
            else if (baud_comboBox.SelectedItem == null)
            {
                MessageBox.Show(this, "BaudRate undefined", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                mainForm.form_home_instance.stop_button.Enabled = false;
                mainForm.form_home_instance.stop_button.ForeColor = System.Drawing.SystemColors.ButtonShadow;
                return;
            }
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

            mainForm.start_python_script(mainForm.python_script_path);

            mainForm.backgroundWorker3.RunWorkerAsync();
        }
    }
}
