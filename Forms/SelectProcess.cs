using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UN5CharPrmEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static WindowsFormsApp1.Main;

namespace WindowsFormsApp1
{
    public partial class SelectProcess : Form
    {
        public ListBox ListBox1 { get { return listBox1; } }
        Main form1Instance = new Main();
        public SelectProcess(Main main)
        {
            InitializeComponent();
            form1Instance = main;
            ListBox1.SelectedIndexChanged += ListBox1_SelectedIndexChanged;
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListBox1.SelectedItem != null)
            {
                ProcessDetails selectedProcess = (ProcessDetails)ListBox1.SelectedItem;
                var pcsx2Process = Process.GetProcessById(selectedProcess.Id);
                eeAddress = (ulong)pcsx2Process.MainModule.BaseAddress;
                
                string path = @"pcsx2_offsetreader.exe";
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = path,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                using (Process process = new Process { StartInfo = psi })
                {
                    process.Start();
                    while (!process.StandardOutput.EndOfStream)
                    {
                        string line = process.StandardOutput.ReadLine();
                        if(line.Contains("EEmem"))
                        {
                            string eeOffsStr = line.Split(new string[] { "->" }, StringSplitOptions.None)[1];
                            eeAddress = ulong.Parse(eeOffsStr, System.Globalization.NumberStyles.HexNumber);
                        }
                    }
                    process.WaitForExit();
                }         

                form1Instance.SelectedProcess(selectedProcess.Id);
                this.Close();
            }
        }

        public void AdicionarItemListBox(object item)
        {
            listBox1.Items.Add(item);
        }
    }
}
