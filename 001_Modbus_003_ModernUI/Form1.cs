using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyModbus;
using MaterialSkin.Controls;
using _001_Modbus_003_ModernUI.Properties;


namespace _001_Modbus_003_ModernUI
{
    public partial class Form1 : Form
    {
        public ModbusClient modbus_client = null;                  // Modbus Client
        DataTable table = new DataTable("table");                   // DataTable for displaying the Predicted Encoder values + Bottles Classes

        public const int sensor_address = 2;                       // Address of Sensor
        public const int encoder_address = 200;                    // Address of Encoder
        public const int y_enc_address = 0x0A;                     // Address of Predicted Encoder, Address of Predicted Class of Bottle is y_enc_address +=1

        public bool image_is_open = false;
        public bool script_is_open = false;

        private const int N1_OFFSET = 100;
        private const int N2_OFFSET = 200;
        private const int N3_OFFSET = 300;
        private const int N4_OFFSET = 400;
        public int[] offset_value = new int[] { N1_OFFSET, N2_OFFSET, N3_OFFSET, N4_OFFSET };      // Values of Ejectors offsets from Camera along the Conveyor Belt axis

        public Queue<(int, string)> event_queue = new Queue<(int, string)>();            // Queue holds the captured image
        public const int event_queue_size = 10;                                  // Maximum captured images stored in queue

        Queue<(int, int)> value = new Queue<(int, int)>();                       // Queue holds the Predicted Encoder values + Predicted Bottles Classes

        public string python_path;
        public string python_script_path;                                                // Path of Model's Python path
        public string image_path;                                                        // Path of Capured Image's path
        public DirectoryInfo directory;

        public Process python_process;
        public StreamWriter python_stdin;
        public StreamReader python_stdout;

        private readonly object modbus_lock = new object();
        private readonly object queue_lock = new object();
        private readonly object event_queue_lock = new object();

        public static AutoResetEvent event_queue_is_empty = new AutoResetEvent(false);
        public static AutoResetEvent value_queue_is_empty = new AutoResetEvent(false);

        public BaslerCamera camera;
        public bool camera_is_open = false;
        public int count = 0;

        public form_setting form_setting_instance;
        public form_home form_home_instance;

        private Stopwatch stopwatch;

        /// <summary>
        /// Helper Function for deleting a file through multiple attemps.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="maxRetries"></param>
        /// <param name="delayMs"></param>
        /// <returns></returns>
        private bool TryDeleteFile(string filePath, int maxRetries = 3, int delayMs = 1)
        {
            for (int i = 0; i < maxRetries; i++)
            {
                try
                {
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                        return true;
                    }
                    return false;
                }
                catch (IOException)
                {
                    if (i == maxRetries - 1) return false; // Give up after max retries
                    Thread.Sleep(delayMs); // Wait before retrying
                }
            }
            return false;
        }


        /// <summary>
        /// This function initializes the Python Script once at the beginning.
        ///     It is activated whenever the 'Run Classifer' button is clicked.
        /// </summary>
        /// <param name="_python_script_path"></param>
        public void start_python_script(string _python_script_path)
        {
            //string python_path = @"C:\Users\QUOCHUY\AppData\Local\Programs\Python\Python311\python.exe";
            ProcessStartInfo psi = new ProcessStartInfo()
            {
                FileName = python_path,
                Arguments = $"\"{_python_script_path}\"",
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };

            python_process = new Process { StartInfo = psi };
            python_process.Start();

            python_stdin = python_process.StandardInput;
            python_stdout = python_process.StandardOutput;
        }


        /// <summary>
        /// This function reads results from AI model inference
        ///     The results is organized as follows:
        ///         - feedback_image_path:   Path to processed image
        ///         - bottle_class:          Class of bottle
        /// </summary>
        /// <param name="_image_path"></param>
        /// <returns></returns>
        public (string, int) read_from_python(string _image_path)
        {

            python_stdin.WriteLine("{0}", _image_path);
            python_stdin.Flush();

            string feedback_image_path = python_stdout.ReadLine();
            int bottle_class = int.Parse(python_stdout.ReadLine());

            return (feedback_image_path, bottle_class);
        }

        public Form1()
        {
            InitializeComponent();

            stopwatch = new Stopwatch();

            this.home_form_load_panel.Controls.Clear();

            form_home_instance = new form_home(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            form_setting_instance = new form_setting(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };

            form_home_instance.FormBorderStyle = FormBorderStyle.None;
            this.home_form_load_panel.Controls.Add(form_home_instance);
            form_home_instance.Show();

        }


        private void home_button_Click(object sender, EventArgs e)
        {
            navigation_panel.Height = home_button.Height;
            navigation_panel.Top = home_button.Top;
            navigation_panel.Left = home_button.Left;
            home_button.BackColor = ColorTranslator.FromHtml("#F8F4EC");
            home_button.ForeColor = ColorTranslator.FromHtml("#121212");
            setting_button.BackColor = ColorTranslator.FromHtml("#402b3a");
            setting_button.ForeColor = ColorTranslator.FromHtml("#F8F4EC");

            this.home_form_load_panel.Controls.Clear();
            this.home_form_load_panel.Controls.Add(form_home_instance);
            form_home_instance.Show();
        }

        private void setting_button_Click(object sender, EventArgs e)
        {
            navigation_panel.Height = setting_button.Height;
            navigation_panel.Top = setting_button.Top;
            navigation_panel.Left = setting_button.Left;
            setting_button.BackColor = ColorTranslator.FromHtml("#F8F4EC");
            setting_button.ForeColor = ColorTranslator.FromHtml("#121212");
            home_button.BackColor = ColorTranslator.FromHtml("#402b3a");
            home_button.ForeColor = ColorTranslator.FromHtml("#F8F4EC");

            this.home_form_load_panel.Controls.Clear();
            this.home_form_load_panel.Controls.Add(form_setting_instance);
            form_setting_instance.Show();
        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void program_load(object sender, EventArgs e)
        {
            table.Columns.Add("Encoder Feedback", Type.GetType("System.Int32"));
            table.Columns.Add("Predicted Class", Type.GetType("System.String"));

            form_home_instance.dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            form_home_instance.dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            form_home_instance.dataGridView1.RowTemplate.Height = 25;

            form_home_instance.dataGridView1.DataSource = table;

            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            cmd.StandardInput.WriteLine("where python");
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();

            for (int i = 0; i < 4; i++)
            { cmd.StandardOutput.ReadLine(); }

            python_path = cmd.StandardOutput.ReadLine();
        }


        /// <summary>
        /// This function populates available COM ports
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void com_comboBox_click(object sender, EventArgs e)
        {
            form_setting_instance.com_comboBox.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            form_setting_instance.com_comboBox.Items.AddRange(ports);
            if (form_setting_instance.com_comboBox.Items.Count > 1)
            {
                form_setting_instance.com_comboBox.SelectedItem = ports[0];
            }
        }

        public void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            bool prev_sensor_response = false;
            bool curr_sensor_response = false;
            int[] temporary_storage = new int[2];
            int encoder_feedback = 0;
            bool condition_sastified = false;
            while (!backgroundWorker1.CancellationPending)
            {
                lock (modbus_lock)
                {

                    curr_sensor_response = modbus_client.ReadCoils(sensor_address, 1)[0];
                    if (curr_sensor_response && !prev_sensor_response)
                    {
                        temporary_storage = modbus_client.ReadHoldingRegisters(encoder_address, 2);
                        encoder_feedback = ((temporary_storage[0] & 0xFFFF) | (temporary_storage[1] << 16));
                        condition_sastified = true;
                        stopwatch.Restart();
                    }
                    prev_sensor_response = curr_sensor_response;
                }

                if (condition_sastified == true)
                {
                    condition_sastified = false;

                    lock (event_queue_lock)
                    {
                        if (event_queue.Count != event_queue_size && camera_is_open == true)                     // If the event_queue is not full and Camera is currently available
                        {                                                                                        //     , then, proceed.
                            string message = camera.camera_oneshot_capture(image_path, count);
                            if (message == "Image is captured successfully")
                            {
                                string image_file = Path.Combine(image_path, "captured_image" + count.ToString() + ".png");
                                event_queue.Enqueue((encoder_feedback, image_file));
                                string temp_path = Path.Combine(image_path, "captured_image_temp.png");
                                File.Copy(image_file, temp_path, true);                                           // Populates the current reading file, free the file for latter deleting

                                if (count == event_queue_size - 1)                                                // If the indexing reaches the limit, the index must return
                                {
                                    count = 0;
                                }
                                else
                                {
                                    count++;
                                }

                                if (event_queue.Count == 1)                                                        // If Event Queue is previously empty and the element size is now 1 
                                {                                                                                  //    ,then, trigger the BackgroundThread3 for executing Model Inference Mode
                                    event_queue_is_empty.Set();
                                }
                            }
                            else
                            {
                                this.Invoke((Action)(() =>
                                {
                                    MessageBox.Show(this, message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                }));
                            }
                        }
                    }
                }
            }
        }

        public void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!backgroundWorker2.CancellationPending)
            {
                value_queue_is_empty.WaitOne();
                while (true)
                {
                    int a = -1;
                    int b = -1;

                    lock (queue_lock)
                    {
                        if (value.Count > 0)
                        {
                            (a, b) = value.Dequeue();
                        }
                        else
                        {
                            break;
                        }
                    }

                    lock (modbus_lock)
                    {
                        if (a >= 50000)
                        {
                            a -= 50000;
                        }
                        try
                        {
                            modbus_client.WriteMultipleRegisters(y_enc_address, new int[] { 1, (a & 0xFFFF), (a >> 16) & 0xFFFF, b });
                            stopwatch.Stop();
                            this.Invoke((Action)(() =>
                            {
                                MessageBox.Show(this, "Time elapsed: " + stopwatch.ElapsedMilliseconds + " ms", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }));
                        }
                        catch (Exception ex)
                        {
                            this.Invoke((Action)(() =>
                            {
                                MessageBox.Show(this, $"Failed to Transmit Data\nError: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }));
                        }
                    }
                }
            }
        }

        public void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!backgroundWorker3.CancellationPending)
            {
                event_queue_is_empty.WaitOne();
                while (true)
                {
                    string image_file = string.Empty;
                    int encoder_feedback = 0;

                    string feedback_image_path = string.Empty;
                    int bottle_class = -1;

                    lock (event_queue_lock)
                    {
                        if (event_queue.Count == 0)
                        {
                            break;
                        }
                        (encoder_feedback, image_file) = event_queue.Dequeue();
                    }

                    (feedback_image_path, bottle_class) = read_from_python(image_file);
                    if (bottle_class != 10 && bottle_class != -1)
                    {
                        encoder_feedback += offset_value[bottle_class];
                        lock (queue_lock)
                        {
                            value.Enqueue((encoder_feedback, bottle_class));
                            if (value.Count == 1)
                            {
                                value_queue_is_empty.Set();
                            }
                        }

                        this.Invoke((Action)(() =>
                        {
                            form_home_instance.pictureBox.Image = Image.FromFile(feedback_image_path);
                            DataRow newRow = table.NewRow();
                            newRow["Encoder Feedback"] = encoder_feedback;
                            newRow["Predicted Class"] = bottle_class.ToString();
                            table.Rows.InsertAt(newRow, 0);
                        }));
                    }
                    else
                    {
                        this.Invoke((Action)(() =>
                        {
                            form_home_instance.pictureBox.Image = Image.FromFile(feedback_image_path);
                            DataRow newRow = table.NewRow();
                            newRow["Encoder Feedback"] = -1;
                            newRow["Predicted Class"] = -1;
                            table.Rows.InsertAt(newRow, 0);
                        }));
                    }

                    if (!TryDeleteFile(image_file))
                    {
                        this.Invoke((Action)(() =>
                        {
                            MessageBox.Show(this, "Could not Delete file", "User Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }));
                    }
                }
            }
        }
    }
}
