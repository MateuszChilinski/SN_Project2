using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SN2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FileComboBox.DropDown += FileComboBox_DropDown;
            StartButton.Click += StartButton_Click;
        }
        private int x = 0;
        private int y = 0;
        private int pythonStatus = 0;
        private void StartButton_Click(object sender, EventArgs e)
        {
            string mydir = "data/";
            pythonStatus = 0;
            string method = MethodComboBox.SelectedItem.ToString().Contains("Hebb") ? "hebb" : "oja";
            string[] resolution = FileComboBox.SelectedItem.ToString().Split('.')[0].Split('-')[1].Split('x');
            x = Int32.Parse(resolution[0]);
            y = Int32.Parse(resolution[1]);
            int asyncParm = AsyncCheckBox.Checked ? 1 : 0;
            var cmd = "-u nn.py";
            var args = mydir + (string)FileComboBox.SelectedItem + " " + (double)NoiseValue.Value/100.0 + " " + method + " " + asyncParm;
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "C:/Program Files (x86)/Microsoft Visual Studio/Shared/Python37_64/python.exe",
                    Arguments = cmd + " " + args,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                },
                EnableRaisingEvents = true
            };
            process.ErrorDataReceived += Process_OutputDataReceived;
            process.OutputDataReceived += Process_OutputDataReceived;
            Debug.WriteLine(cmd + " " + args);
            process.Start();
            process.BeginOutputReadLine();
        }

        private void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data == null) return;
            Debug.WriteLine(e.Data);
            string data = e.Data.ToString();
            if(data.Substring(0,1) == "[")
            {
                int minus = 1;
                if(data.Substring(0, 2) == "[-")
                    minus = 0;
                data = data.Substring(1+ minus, data.Length - (2+ minus)).Replace("  ", " ").Replace(".", "");
                var numbers = data.Split(' ');
                int[] arr = Array.ConvertAll(numbers, s => int.Parse(s));
                for (int i = 0; i < arr.Length; i++)
                    arr[i] = (arr[i] == -1) ? 0 : 255;
                byte[] arrByte = Array.ConvertAll(arr, s => (byte)s);
                var arr2d = Make2DArray(arrByte, x, y);
                TypeConverter tc = TypeDescriptor.GetConverter(typeof(Bitmap));

                Bitmap bm = new Bitmap(x * 100, y * 100);
                using (Graphics g = Graphics.FromImage(bm))
                {
                    for (int i = 0; i < arr2d.GetLength(0); i++)
                    {
                        for (int j = 0; j < arr2d.GetLength(1); j++)
                        {
                            if(arr2d[i,j] == 255)
                                g.FillRectangle(Brushes.Black, i * 10, j * 10, 10, 10);
                            else
                                g.FillRectangle(Brushes.White, i * 10, j * 10, 10, 10);
                        }
                    }
                }

                if (pythonStatus == 0)
                {
                    OriginalPictureBox.Invoke((MethodInvoker)(() =>
                    {
                        OriginalPictureBox.Image = bm;
                    }
                    ));
                    pythonStatus = 1;
                }
                else if (pythonStatus == 1)
                {
                    MainPictureBox.Invoke((MethodInvoker)(() =>
                    {
                        MainPictureBox.Image = bm;
                    }
                    ));
                }
            }
        }

        private void FileComboBox_DropDown(object sender, EventArgs e)
        {
            string mydir = "data/";
            FileComboBox.Items.Clear();
            string[] files = Directory.GetFiles(mydir);

            foreach (string filePath in files)
            {
                FileComboBox.Items.Add(Path.GetFileName(filePath));
            }
        }

        private static T[,] Make2DArray<T>(T[] input, int height, int width)
        {
            T[,] output = new T[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    output[i, j] = input[i * width + j];
                }
            }
            return output;
        }
    }
}
