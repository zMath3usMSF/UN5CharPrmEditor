using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using System.Windows.Forms;
using UN5CharPrmEditor;
using UN5CharPrmEditor.Properties;
using System.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Linq;

namespace WindowsFormsApp1
{
    public partial class Main : Form
    {
        #region Variables
        public static List<int> charInvalid = new List<int> { 0, 8, 9, 20, 21, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 44, 45, 74, 88 };
        public static string caminhoELF;
        public static bool openedELF;
        public static int currentProcessID = 0;
        public static int memoryDif = 0;
        private MovesetParameters movesetParameters;
        private GeneralParameters generalParameters;
        public static int P1ID { get; set; }
        public static bool isNA2;
        public static bool isUN6;
        IntPtr bytesRead;
        public static List<byte[]> charMainAreaList = new List<byte[]>();
        public static List<string> charName = new List<string>();
        public static List<string> charCCS = new List<string>();
        public static List<string> mapNameList = new List<string>();
        #endregion
        #region MemoryProcessFunctions
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern bool CloseHandle(IntPtr hObject);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int dwSize, out IntPtr lpNumberOfBytesRead);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out int lpNumberOfBytesWritten);

        public const int PROCESS_VM_WRITE = 0x0020;
        public const int PROCESS_VM_OPERATION = 0x0008;
        public const int PROCESS_VM_READ = 0x0010;
        public const int PROCESS_ALL_ACCESS = 0x1F0FFF;
        public const int PROCESS_VM_READWRITE = PROCESS_VM_READ | PROCESS_VM_WRITE | PROCESS_VM_OPERATION;
        public int GetProcessId(string processName)
        {
            Process[] processes = Process.GetProcessesByName(processName);
            if (processes.Length > 0)
            {
                return processes[0].Id;
            }
            return -1;
        }
        public class ProcessDetails
        {
            public string Name { get; set; }
            public int Id { get; set; }

            public ProcessDetails(string name, int id)
            {
                Name = name;
                Id = id;
            }
            public override string ToString()
            {
                return $"{Name} (ID: {Id})";
            }
        }
        #endregion
        public Main()
        {
            InitializeComponent();
            lstChar.SelectedIndexChanged += lstChar_AfterSelect;
            movesetParameters = new MovesetParameters();
            generalParameters = new GeneralParameters();

            if (Settings.Default.EnglishChecked == true)
            {
                englishToolStripMenuItem.Checked = true;
            }
            else
            {
                portuguêsToolStripMenuItem.Checked = true;
            }
        }
        public void SelectedProcess(int idDoProcessoSelecionado)
        {
            currentProcessID = idDoProcessoSelecionado;

            ProcessListBoxSelectedItem(idDoProcessoSelecionado);
        }

        private void LoadRunningProcesses()
        {
            Process[] processes = Process.GetProcesses();
            SelectProcess selectProcess = new SelectProcess(this);
            for (int i = 0; i < processes.Count(); i++)
            {
                if (processes[i].ProcessName.ToLower().Contains("pcsx2"))
                {
                    ProcessDetails processDetails = new ProcessDetails(processes[i].ProcessName, processes[i].Id);

                    selectProcess.AdicionarItemListBox(processDetails);
                }
                if(i == processes.Count() - 1 & processes[i].ProcessName.ToLower().Contains("pcsx2") == false)
                {
                    if(selectProcess.ListBox1.Items.Count == 0 & processes[i].ProcessName.ToLower().Contains("pcsx2") == false)
                    {
                        MessageBox.Show("PCSX2 process not found, open PCSX2 with the game running and try again.");
                        return;
                    }
                    selectProcess.ShowDialog();
                }
            }
            return;
        }

        private void lstChar_AfterSelect(object sender, EventArgs e)
        {
            btnEditGeneralParameters.Visible = true;
            btnEditMovesetParameters.Visible = true;

            string selectedString = lstChar.SelectedItem.ToString();

            string[] splitString = selectedString.Split(':');
            if (splitString.Length > 1)
            {
                charCCS.Clear();
                string charIDString = splitString[0].Trim();
                int charID = Convert.ToInt32(charIDString);
                txtcharName.Text = ($"{charName[charID]}");
                lblcharName.Visible = true;
                txtcharName.Visible = true;
                txtCCSName.Text = GetCharCCSName(charID);
                txtCCSName.Visible = true;
                lblCCSName.Visible = true;

                int nodeIndex = lstChar.SelectedIndex;

                if ((nodeIndex >= 29 && nodeIndex <= 38) || nodeIndex >= 55 && nodeIndex <= 56)
                {
                    if ((nodeIndex >= 55 && nodeIndex <= 56))
                    {
                        nodeIndex = nodeIndex - 51;

                        int x = (nodeIndex % 3) * 170;
                        int y = ((nodeIndex / 3) % 2) * 256;

                        Rectangle cropArea = new Rectangle(x, y, 170, 256);

                        string resourceName = $"pure_home_92";

                        Bitmap croppedImage = Resources.ResourceManager.GetObject(resourceName) as Bitmap;

                        croppedImage = croppedImage.Clone(cropArea, croppedImage.PixelFormat);

                        pictureBox1.Image = croppedImage;
                    }
                    else
                    {
                        if ((nodeIndex >= 29 && nodeIndex <= 38))
                        {
                            nodeIndex = nodeIndex - 29;
                        }

                        int imageNumber = nodeIndex / 6 + 1;

                        int x = (nodeIndex % 3) * 170;
                        int y = ((nodeIndex / 3) % 2) * 256;

                        Rectangle cropArea = new Rectangle(x, y, 170, 256);

                        string resourceName = $"pure_home_9{imageNumber}";

                        Bitmap croppedImage = Resources.ResourceManager.GetObject(resourceName) as Bitmap;

                        croppedImage = croppedImage.Clone(cropArea, croppedImage.PixelFormat);

                        pictureBox1.Image = croppedImage;
                    }
                }
                else
                {
                    if (nodeIndex >= 38 && nodeIndex <= 54)
                    {
                        nodeIndex = nodeIndex - 10;
                    }
                    if (nodeIndex >= 57)
                    {
                        nodeIndex = nodeIndex - 12;
                    }

                    int imageNumber = nodeIndex / 6 + 1;

                    string resourceName = $"pure_home_{imageNumber:D2}";

                    Bitmap croppedImage = Resources.ResourceManager.GetObject(resourceName) as Bitmap;

                    int x = (nodeIndex % 3) * 170;
                    int y = ((nodeIndex / 3) % 2) * 256;

                    Rectangle cropArea = new Rectangle(x, y, 170, 256);

                    croppedImage = croppedImage.Clone(cropArea, croppedImage.PixelFormat);

                    pictureBox1.Image = croppedImage;
                }
            }
        }

        private void ClearAllList()
        {
            lstChar.Items.Clear();
            charMainAreaList.Clear();
            charName.Clear();
            charCCS.Clear();
            mapNameList.Clear();

            CharGen.CharGenPrm.Clear();
            CharGen.CharGenPrmBkp.Clear();

            CharAtk.CharAtkPrm.Clear();
            CharAtk.CharAtkPrmBkp.Clear();
            CharAtk.comboNameList.Clear();

            CharAnm.CharAnmPrm.Clear();
            CharAnm.CharAnmPrmBkp.Clear();
            CharAnm.charAnmNameList.Clear();
        }

        public void ProcessListBoxSelectedItem(int selectedProcessId)
        {
            IntPtr processHandle = OpenProcess(PROCESS_VM_READ, false, selectedProcessId);
            if (processHandle != IntPtr.Zero)
            {
                byte[] currentMemoryStartBytes = new byte[4];
                ReadProcessMemory(processHandle, (IntPtr)0x20617EF4, currentMemoryStartBytes, currentMemoryStartBytes.Length, out var none);
                int currentMemoryStart = BitConverter.ToInt32(currentMemoryStartBytes, 0);

                isNA2 = currentMemoryStart == 0 ? true : false;

                int originalMemoryStart = 0xBD4560;

                memoryDif = currentMemoryStart - originalMemoryStart;

                byte[] buffer = new byte[2];
                if(isNA2 == true)
                {
                    if (ReadProcessMemory(processHandle, (IntPtr)0x201F5450, buffer, buffer.Length, out var none1))
                    {
                        ClearAllList();
                        picMainBackground.Visible = false;

                        ushort charNumber = BitConverter.ToUInt16(buffer, 0);
                        int charStringTblOffset = 0x20401AD0;

                        if (charNumber != 94) //Verifica se é o UN6 usando quantidade de personagens presentes originalmente no jogo como base.
                        {
                            isUN6 = true;
                        }

                        ReadCharProgTbl(processHandle, charNumber, 0x205A2900);

                        NA2ReadCharNameTbl(processHandle, charNumber, charStringTblOffset);
                    }
                    else
                    {
                        MessageBox.Show("Error reading process memory, check if the game has already started or if the PCSX2 version is 1.6 or earlier and try again.");
                        return;
                    }
                    CloseHandle(processHandle);
                }
                else
                {
                    if (ReadProcessMemory(processHandle, (IntPtr)0x201EDA20, buffer, buffer.Length, out var none1))
                    {
                        ClearAllList();
                        picMainBackground.Visible = false;

                        ushort charNumber = BitConverter.ToUInt16(buffer, 0);
                        int charStringTblOffset = 0x205BA570;

                        if (charNumber != 94) //Verifica se é o UN6 usando quantidade de personagens presentes originalmente no jogo como base.
                        {
                            isUN6 = true;
                        }

                        if (isUN6 == true)
                        {
                            int charProgTblOffset = 0x20417D00;

                            ReadCharProgTbl(processHandle, charNumber, charProgTblOffset);
                        }
                        else
                        {
                            int charProgTblOffset = 0x205AC8C0;

                            ReadCharProgTbl(processHandle, charNumber, charProgTblOffset);
                        }

                        ReadCharNameTbl(processHandle, charNumber, charStringTblOffset);
                    }
                    else
                    {
                        MessageBox.Show("Error reading process memory, check if the game has already started or if the PCSX2 version is 1.6 or earlier and try again.");
                        return;
                    }
                    CloseHandle(processHandle);
                }
            }
            else
            {
                MessageBox.Show("Unable to open the process.");
            }
            lstChar.SelectedIndex = 0;
        }
        public void NA2ReadCharNameTbl(IntPtr processHandle, int charNumber, int charStringTblOffset)
        {
            IntPtr NewcharOffset = (IntPtr)charStringTblOffset;

            byte[] buffer2 = new byte[charNumber * 0x4];
            ReadProcessMemory(processHandle, NewcharOffset, buffer2, buffer2.Length, out var none1);

            for (int i = 0; i < buffer2.Length; i += 4)
            {
                byte[] bytesToRead = new byte[4];
                Array.Copy(buffer2, i, bytesToRead, 0, 4);

                bytesToRead[3] = 0x20;

                int offset = BitConverter.ToInt32(bytesToRead, 0);

                string decodedString = Util.ReadStringWithOffset(offset, true);

                var i3 = i / 4;

                charName.Add(decodedString);

                if (!charInvalid.Contains(i3))
                {
                    if (i3 <= 93)
                    {
                        string charValue = i3.ToString();

                        decodedString = charValue + ": " + decodedString;
                        lstChar.Items.Add(decodedString);
                    }
                    else
                    {
                        break;
                    }
                }
                lstChar.Visible = true;
            }
        }
        public void ReadCharNameTbl(IntPtr processHandle, int charNumber, int charStringTblOffset)
        {
            byte[] charOffsetBytes = new byte[4];
            ReadProcessMemory(processHandle, (IntPtr)charStringTblOffset, charOffsetBytes, charOffsetBytes.Length, out var none);
            charOffsetBytes[3] = 0x20;

            int charOffset = BitConverter.ToInt32(charOffsetBytes, 0);

            IntPtr NewcharOffset = (IntPtr)(charOffset);

            byte[] buffer2 = new byte[charNumber * 0x8];
            ReadProcessMemory(processHandle, NewcharOffset, buffer2, buffer2.Length, out var none1);

            for (int i = 0; i < buffer2.Length; i += 8)
            {
                byte[] subArray = new byte[8];
                Array.Copy(buffer2, i, subArray, 0, 8);

                byte[] bytesToRead = new byte[4];
                Array.Copy(subArray, 4, bytesToRead, 0, 4);

                bytesToRead[3] = 0x20;

                int offset = BitConverter.ToInt32(bytesToRead, 0);

                string decodedString = Util.ReadStringWithOffset(offset, false);

                var i3 = i / 8;

                charName.Add(decodedString);

                if (!charInvalid.Contains(i3))
                {
                    if (i3 <= 93)
                    {
                        string charValue = i3.ToString();

                        decodedString = charValue + ": " + decodedString;
                        lstChar.Items.Add(decodedString);
                    }
                    else
                    {
                        break;
                    }
                }
                lstChar.Visible = true;
            }
        }

        public void ReadCharProgTbl(IntPtr processHandle, int charNumber, int charProgTblOffset)
        {
            byte[] charProgBuffer = new byte[charNumber * 0x8];
            if (ReadProcessMemory(processHandle, (IntPtr)charProgTblOffset, charProgBuffer, charProgBuffer.Length, out bytesRead))
            {
                for (int i = 0; i < charProgBuffer.Length; i += 8)
                {
                    #region Read Char ProgArea and MainArea
                    byte[] charProgAreaBytes = new byte[8];
                    Array.Copy(charProgBuffer, i, charProgAreaBytes, 0, 8);

                    byte[] charMainAreaPointerBytes = new byte[4];
                    Array.Copy(charProgAreaBytes, 4, charMainAreaPointerBytes, 0, 4);

                    charMainAreaPointerBytes[3] = 0x20;

                    int charMainAreaOffsetBytes = BitConverter.ToInt32(charMainAreaPointerBytes, 0);

                    IntPtr charMainAreaOffset = (IntPtr)charMainAreaOffsetBytes;

                    byte[] charMainAreaBuffer = new byte[0x120];
                    ReadProcessMemory(processHandle, charMainAreaOffset, charMainAreaBuffer, charMainAreaBuffer.Length, out bytesRead);

                    charMainAreaList.Add(charMainAreaBuffer);
                    #endregion

                    #region Read General Char Parameters
                    var ninja = CharGen.ReadCharGenPrm(charMainAreaBuffer);
                    var clone = (CharGen)ninja.Clone();
                    CharGen.CharGenPrm.Add(ninja);
                    CharGen.CharGenPrmBkp.Add(clone);
                    #endregion
                }
            }
        }

        public static string GetCharCCSName(int selectedIndex)
        {
            while (charCCS.Count <= 93)
            {
                charCCS.Add("");
            }
            if (charCCS[selectedIndex] == "")
            {   
                byte[] ccsOffsetBytes = CharGen.CharGenPrm[selectedIndex].CCSOffset;
                ccsOffsetBytes[3] = 0x20;
                int ccsPointer = BitConverter.ToInt32(ccsOffsetBytes, 0);

                charCCS[selectedIndex] = Util.ReadStringWithOffset(ccsPointer, false);
            }

            return charCCS[selectedIndex];
        }

        public static string GetMapName(int mapIndex)
        {
            while (mapNameList.Count <= 24)
            {
                mapNameList.Add("");
            }
            if (mapNameList[mapIndex] == "")
            {
                IntPtr processHandle = OpenProcess(PROCESS_VM_READ, false, currentProcessID);

                int mapNameAreaPointer = isNA2 == true ? 0x205C04C0 : 0x205C7970;

                IntPtr mapNameAreaOffset = (IntPtr)mapNameAreaPointer;

                byte[] mapNameAreaBuffer = new byte[24 * 0x4];
                ReadProcessMemory(processHandle, mapNameAreaOffset, mapNameAreaBuffer, mapNameAreaBuffer.Length, out var none2);

                List<string> anmNameList = new List<string>();

                byte[] mapNamePointerBytes = new byte[4];
                Array.Copy(mapNameAreaBuffer, mapIndex * 0x4, mapNamePointerBytes, 0, 4);

                mapNamePointerBytes[3] = 0x20;
                int mapNamePointer = BitConverter.ToInt32(mapNamePointerBytes, 0);

                string decodedMapName = isNA2 == true ? Util.ReadStringWithOffset(mapNamePointer, true) : Util.ReadStringWithOffset(mapNamePointer, false);

                mapNameList[mapIndex] = decodedMapName;
            }

            return mapNameList[mapIndex];
        }

        private void btnEditGeneralParameters_Click(object sender, EventArgs e)
        {
            string selectedString = lstChar.SelectedItem.ToString();

            string[] splitString = selectedString.Split(':');
            if (splitString.Length > 1)
            {
                GeneralParameters genForm = new GeneralParameters();
                string charName = txtcharName.Text;
                int charID = int.Parse(splitString[0].Trim());

                genForm.timer1.Enabled = true;
                genForm.UpdateLabels(charName, charID);
                var charGenPrm = CharGen.CharGenPrm[charID];
                CharGen.SendTextToGenForm(genForm, charGenPrm);
                genForm.Show();
            }
        }

        private void OpenELF()
        {
            var openFileDialog = new OpenFileDialog()
            {
                Title = "Select the ELF.",
                Filter = "ELF Files|*.05;*.06|All Files|*.*"
            };

            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                openedELF = false;
            }
            else
            {
                caminhoELF = openFileDialog.FileName;
                openedELF = true;
                generalParameters.btnSaveELF.Enabled = true;
            }
        }

        private void pCSX2MemoryProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectProcess selectProcess = new SelectProcess(this);
            selectProcess.ListBox1.Items.Clear();
            selectProcess.Owner = this;
            LoadRunningProcesses();
        }

        private void openELFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenELF();
        }

        private void btnEditMovesetParameters_Click(object sender, EventArgs e)
        {
            string selectedString = lstChar.SelectedItem.ToString();

            string[] splitString = selectedString.Split(':');
            if (splitString.Length > 1)
            {
                string charIDString = splitString[0].Trim();
                int charID = Convert.ToInt32(charIDString);
                MovesetParameters movForm = new MovesetParameters();
                string txtCharNameForm = txtcharName.Text;

                movForm.timer1.Enabled = true;
                if (isNA2 == true)
                {
                    for (int i = 0; i < CharGen.CharGenPrm[charID].AtkCount; i++)
                    {
                        CharAtk.SendTextAtk(movForm, CharAtk.GetCharAtk(charID, i));
                    }
                }
                CharAtk.AddCharComboList(movForm, charID, txtCharNameForm);
                movForm.UpdateLabels(txtCharNameForm, charIDString);
                movForm.Show();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("UN5CharPrmEditor, version 0.0. \n\nMade by zMath3usMSF.");
        }

        public void UpdateMatch(bool isP1, int PlayerID, int MapID)
        {
            IntPtr processHandle = OpenProcess(PROCESS_ALL_ACCESS, false, currentProcessID);
            if (processHandle != IntPtr.Zero)
            {
                byte[] Unk3 = new byte[1];
                Unk3[0] = 0x2;

                WriteProcessMemory(processHandle, isNA2 == true ? (IntPtr)0x2060767C : (IntPtr)0x20617D7C, Unk3, (uint)Unk3.Length, out var none3);

                byte[] Unk2 = new byte[1];
                Unk2[0] = 0x1;

                WriteProcessMemory(processHandle, isNA2 == true ? (IntPtr)0x20607678 : (IntPtr)0x20617D78, Unk2, (uint)Unk2.Length, out var none2);

                byte[] Unk1 = new byte[1];
                Unk1[0] = 0x8;

                WriteProcessMemory(processHandle, isNA2 == true ? (IntPtr)0x20607670 : (IntPtr)0x20617D70, Unk1, (uint)Unk1.Length, out var none1);

                byte[] PlayerIDByte = new byte[1];
                PlayerIDByte[0] = (byte)PlayerID;

                IntPtr PlayerOffset = (IntPtr)(isP1 == true ? isNA2 == true ? 0x20C41700 : 0x20BD7AB0  + Main.memoryDif : Main.isNA2 == true ? 0x20C41724 : 0x20BD7AD8  + Main.memoryDif);

                WriteProcessMemory(processHandle, PlayerOffset, PlayerIDByte, (uint)PlayerIDByte.Length, out var none4);

                byte[] MapIDByte = new byte[1];
                MapIDByte[0] = (byte)MapID;

                WriteProcessMemory(processHandle, isNA2 == true ? (IntPtr)0x20C4174A : (IntPtr)0x20BD7AFA + Main.memoryDif, MapIDByte, (uint)MapIDByte.Length, out var none5);

                CloseHandle(processHandle);
            }
        }

        private void changeP1CharacterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateMatch updateMatch = new UpdateMatch(this);
            updateMatch.lblPlayerID.Text = "P1:";
            bool isP1 = true;
            updateMatch.SendText(isP1);
            updateMatch.Show();
        }

        private void changeP2CharacterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateMatch updateMatch = new UpdateMatch(this);
            updateMatch.lblPlayerID.Text = "P2:";
            bool isP1 = false;
            updateMatch.SendText(isP1);
            updateMatch.Show();
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Default.EnglishChecked = true;
            Settings.Default.PortuguesChecked = false;
            Settings.Default.Save();
            portuguêsToolStripMenuItem.Checked = false;
        }

        private void portuguêsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Default.PortuguesChecked = true;
            Settings.Default.EnglishChecked = false;
            Settings.Default.Save();
            englishToolStripMenuItem.Checked = false;
        }
    }
}