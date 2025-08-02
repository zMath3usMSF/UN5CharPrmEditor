using CCSFileExplorerWV;
using DiscUtils.Iso9660;
using ICSharpCode.SharpZipLib.GZip;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using UN5CharPrmEditor;
using UN5CharPrmEditor.Properties;
using static CCSFileExplorerWV.CCSFile;
using static UN5CharPrmEditor.Config;

namespace WindowsFormsApp1
{
    public partial class Main : Form
    {
        #region Variables
        public static List<int> charInvalid = new List<int> { 0, 8, 9, 20, 21, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 44, 45, 74, 88 };
        public static int charCount = 0;
        public static string caminhoELF;
        public static bool openedELF;
        public static int currentProcessID = 0;
        public static int memoryDif = 0;
        private AwakeningParameters awakeningParameters;
        private MovesetParameters movesetParameters;
        private GeneralParameters generalParameters;
        public static ulong eeAddress;
        public static int P1ID { get; set; }
        public static bool isUN6;
        IntPtr bytesRead;
        public static List<int> charMainAreaOffsets = new List<int>();
        public static List<byte[]> charMainAreaList = new List<byte[]>();
        public static List<string> charNameList = new List<string>();
        public static List<string> charCCSList = new List<string>();
        public static List<string> mapNameList = new List<string>();
        string gamePath = "C:\\Users\\zMath3usMSF\\Desktop\\UN6A30\\";
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
            lstChar.SelectedIndexChanged += LstChar_AfterSelect;
            awakeningParameters = new AwakeningParameters();
            movesetParameters = new MovesetParameters();
            generalParameters = new GeneralParameters();

            ReadConfigFile(this);
            if (Settings.Default.EnglishChecked == true)
            {
                englishToolStripMenuItem.Checked = true;
            }
            else
            {
                portuguêsToolStripMenuItem.Checked = true;
            }

            txtGamePath.Text = gamePath;
            CharSel.Create(this, gamePath);
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

        private void LstChar_AfterSelect(object sender, EventArgs e)
        {
            btnEditGeneralParameters.Visible = true;
            btnEditMovesetParameters.Visible = true;
            btnEditAwekeningParameters.Visible = true;
            btnEditJutsusParameters.Visible = false;

            string selectedString = lstChar.SelectedItem.ToString();

            string[] splitString = selectedString.Split(':');
            if (splitString.Length > 1)
            {
                charCCSList.Clear();
                string charIDString = splitString[0].Trim();
                int charID = Convert.ToInt32(charIDString);
                txtcharName.Text = charID > 94 ? "???" : $"{charNameList[charID]}";
                lblcharName.Visible = true;
                txtcharName.Visible = true;
                txtCCSName.Text = GetCharCCSName(charID);
                txtCCSName.Visible = true;
                lblCCSName.Visible = true;

                int nodeIndex = lstChar.SelectedIndex;

                if(nodeIndex > 73)
                {
                    int imageNumber = nodeIndex / 6 + 1;

                    string resourceName = $"pure_home_{11:D2}";

                    Bitmap croppedImage = Resources.ResourceManager.GetObject(resourceName) as Bitmap;

                    int x = 2 * 170;
                    int y = 0;

                    Rectangle cropArea = new Rectangle(x, y, 170, 256);

                    croppedImage = croppedImage.Clone(cropArea, croppedImage.PixelFormat);

                    pictureBox1.Image = croppedImage;
                }
                else
                {
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
        }

        private void ClearAllList()
        {
            lstChar.Items.Clear();
            charMainAreaOffsets.Clear();
            charMainAreaList.Clear();
            charNameList.Clear();
            charCCSList.Clear();
            mapNameList.Clear();

            PlGen.CharGenPrm.Clear();
            PlGen.CharGenPrmBkp.Clear();

            PlAtk.CharAtkPrm.Clear();
            PlAtk.CharAtkPrmBkp.Clear();
            PlAtk.comboNameList.Clear();

            PlAnm.PlAnmPrm.Clear();
            PlAnm.PlAnmPrmBkp.Clear();
            PlAnm.PlAnmListName.Clear();

            PlAwk.CharAwkPrm.Clear();
            PlAwk.CharAwkPrmBkp.Clear();
            PlAwk.CharAwkIDList.Clear();
            PlAwk.CharAwkActivationType.Clear();
            PlAwk.CharAwkActivationSound.Clear();

        }

        public void ProcessListBoxSelectedItem(int selectedProcessId)
        {
            IntPtr processHandle = OpenProcess(PROCESS_VM_READ, false, selectedProcessId);
            if (processHandle != IntPtr.Zero)
            {
                int currentMemoryStart = Util.ReadProcessMemoryInt32(0x617EF4);
                int originalMemoryStart = 0xBD4560;

                memoryDif = currentMemoryStart - originalMemoryStart;

                charCount = Util.ReadProcessMemoryInt16(0x1EDA20);
                if(Util.ReadStringWithOffset(0x417CD0, false) == "2nrtbod1.ccs")
                {
                    ClearAllList();
                    picMainBackground.Visible = false;


                    int charStringTblOffset = 0x5BA570;
                    if (charCount != 94) //Verifica se é o UN6 usando quantidade de personagens presentes originalmente no jogo como base.
                    {
                        isUN6 = true;
                    }
                    int charProgTblOffset = 0x5AC8C0;

                    ReadCharProgDataTbl(processHandle, charProgTblOffset);

                    ReadCharNameTbl(processHandle, charStringTblOffset);
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
                MessageBox.Show("Unable to open the process.");
            }
            lstChar.SelectedIndex = 0;
        }
        public void ReadCharNameTbl(IntPtr processHandle, int charStringTblOffset)
        {
            int charNameTblOffs = Util.ReadProcessMemoryInt32(charStringTblOffset);
            for (int i = 0; i < charCount; i++)
            {
                int charNameOffs = Util.ReadProcessMemoryInt32(charNameTblOffs + i * 8);
                string charName = Util.ReadStringWithOffset(charNameOffs, false);

                int charFullNameOffs = Util.ReadProcessMemoryInt32(charNameTblOffs + i * 8 + 4);
                string charFullName = Util.ReadStringWithOffset(charFullNameOffs, false);
                charNameList.Add(charFullName);

                if (!charInvalid.Contains(i))
                {
                    if (i <= 93)
                    {
                        string charValue = i.ToString();

                        charFullName = charValue + ": " + charFullName;
                        lstChar.Items.Add(charFullName);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            for (int j = 0; j < charCount - 94; j++)
            {
                lstChar.Items.Add($"{94 + j}: {GetCharCCSName(94 + j)}");
            }
            lstChar.Visible = true;
        }

        public void ReadCharProgDataTbl(IntPtr processHandle, int charProgDataTblOffs)
        {
            
            for (int i = 0; i < 0x5E; i++)
            {
                #region Read Character MIPS Offset and Character Data
                int charDataOffs = Util.ReadProcessMemoryInt32(charProgDataTblOffs + (i * 8) + 4);
                charMainAreaOffsets.Add(charDataOffs);

                byte[] charMainAreaBuffer = Util.ReadProcessMemoryBytes(charDataOffs, 0x120);
                charMainAreaList.Add(charMainAreaBuffer);
                #endregion

                #region Read General Char Parameters
                var ninja = PlGen.ReadCharGenPrm(charMainAreaBuffer);
                var clone = (PlGen)ninja.Clone();
                PlGen.CharGenPrm.Add(ninja);
                PlGen.CharGenPrmBkp.Add(clone);
                #endregion
            }
            PlAwk.ReadCharAwkIDList();
            if (isUN6 == true)
            {
                for (int i = 0; i < charCount - 0x5D; i++)
                {
                    #region Read Character MIPS Offset and Character Data
                    int charDataOffs = Util.ReadProcessMemoryInt32(0x956100 + (i * 8) + 4);
                    charMainAreaOffsets.Add(charDataOffs);

                    byte[] charMainAreaBuffer = Util.ReadProcessMemoryBytes(charDataOffs, 0x120);
                    charMainAreaList.Add(charMainAreaBuffer);
                    #endregion

                    #region Read General Char Parameters
                    var ninja = PlGen.ReadCharGenPrm(charMainAreaBuffer);
                    var clone = (PlGen)ninja.Clone();
                    PlGen.CharGenPrm.Add(ninja);
                    PlGen.CharGenPrmBkp.Add(clone);
                    #endregion
                }
                PlAwk.ReadCharAwkIDList();
            }
        }

        public static string GetCharCCSName(int selectedIndex)
        {
            while (charCCSList.Count <= charCount)
            {
                charCCSList.Add("");
            }
            if (charCCSList[selectedIndex] == "")
            {   
                byte[] ccsOffsetBytes = PlGen.CharGenPrm[selectedIndex].CCSOffset;
                int ccsPointer = BitConverter.ToInt32(ccsOffsetBytes, 0);

                charCCSList[selectedIndex] = Util.ReadStringWithOffset(ccsPointer, false);
            }

            return charCCSList[selectedIndex];
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
                int mapNameAreaPointer = 0x5C7970;

                int mapNameOffs = Util.ReadProcessMemoryInt32(mapNameAreaPointer + (mapIndex * 4));
                string decodedMapName = Util.ReadStringWithOffset(mapNameOffs, false);
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
                var charGenPrm = PlGen.CharGenPrm[charID];
                PlGen.SendTextToGenForm(genForm, charGenPrm);
                genForm.Show();
            }
        }

        private void OpenELF()
        {
            var openFileDialog = new OpenFileDialog()
            {
                Title = "Select the ELF.",
                Filter = "ELF Files|*.05;*.06;*.37|All Files|*.*"
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
                PlAtk.AddCharComboList(movForm, charID, txtCharNameForm);
                movForm.UpdateLabels(txtCharNameForm, charIDString);
                movForm.Show();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("UN5CharPrmEditor, version 1.4. \n\nMade by zMath3usMSF.");
        }

        public void UpdateMatch(bool isP1, int PlayerID, int MapID)
        {
            IntPtr processHandle = OpenProcess(PROCESS_ALL_ACCESS, false, currentProcessID);
            if (processHandle != IntPtr.Zero)
            {
                byte[] Unk3 = new byte[1];
                Unk3[0] = 0x2;
                Util.WriteProcessMemoryBytes(0x617D7C, Unk3);

                byte[] Unk2 = new byte[1];
                Unk2[0] = 0x1;
                Util.WriteProcessMemoryBytes(0x617D78, Unk2);

                byte[] Unk1 = new byte[1];
                Unk1[0] = 0x8;
                Util.WriteProcessMemoryBytes(0x617D70, Unk1);

                byte[] PlayerIDByte = new byte[1];
                PlayerIDByte[0] = (byte)PlayerID;
                Util.WriteProcessMemoryBytes(isP1 == true ? 0xBD7AB0 + Main.memoryDif : 0xBD7AD8 + Main.memoryDif, PlayerIDByte);

                byte[] MapIDByte = new byte[1];
                MapIDByte[0] = (byte)MapID;
                Util.WriteProcessMemoryBytes(0xBD7AFA + Main.memoryDif, MapIDByte);

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

        private void btnEditAwekeningParameters_Click(object sender, EventArgs e)
        {
            string selectedString = lstChar.SelectedItem.ToString();

            string[] splitString = selectedString.Split(':');
            if (splitString.Length > 1)
            {
                string charIDString = splitString[0].Trim();
                int charID = Convert.ToInt32(charIDString);
                AwakeningParameters awkForm = new AwakeningParameters();
                string txtCharNameForm = txtcharName.Text;

                awkForm.timer1.Enabled = true;
                PlAwk.AddItemsToListBox(awkForm, charID);
                awkForm.UpdateLabels(txtCharNameForm, charIDString);
                awkForm.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectedString = lstChar.SelectedItem.ToString();

            string[] splitString = selectedString.Split(':');
            if (splitString.Length > 1)
            {
                JutsuParameters jtsForm = new JutsuParameters();
                string charName = txtcharName.Text;
                string charID = splitString[0].Trim();

                jtsForm.timer1.Enabled = true;
                jtsForm.UpdateLabels(charName, charID);
                jtsForm.AddToListBox(int.Parse(charID));
                jtsForm.Show();
            }
        }

        private void defaultToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            ChangedTheme(this, "default");
        }

        private void blackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangedTheme(this, "black");
        }

        private void addNewCharacterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewChar ok = new NewChar();
            ok.Show();
        }

        private void btnSelectGamePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if(fbd.ShowDialog() == DialogResult.OK)
            {
                string ok = fbd.SelectedPath;
                txtGamePath.Text = ok;
            }
        }

        private void txtGamePath_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void extractCVMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                lblProgress.Text = "Extracting ISO...";
                string gameFile = ofd.FileName;
                string gamePath = Path.Combine(Path.GetDirectoryName(gameFile), "GAME");
                using (FileStream isoStream = File.OpenRead(gameFile))
                {
                    CDReader cd = new CDReader(isoStream, true);
                    ExtrairArquivos(cd, @"\", gamePath);
                }

                lblProgress.Text = "Extracting CVM data...";
                string path = @"CVM Tool\cvm_tool.exe";
                string cvm = Path.Combine(gamePath, "DATA\\DATA.CVM");
                string iso = Path.Combine(gamePath, "DATA\\data.iso");
                string rofs = Path.Combine(gamePath, "DATA\\ROFS");
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = path,
                    Arguments = $"split \"{cvm}\" \"{iso}\" data.hdr",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                Process process = Process.Start(psi);
                process.WaitForExit();

                using (FileStream isoStream = File.OpenRead(iso))
                {
                    CDReader cd = new CDReader(isoStream, true);
                    ExtrairArquivos(cd, @"\", rofs);
                }

                File.Delete(cvm);
                File.Delete(iso);

                foreach (string file in Directory.GetFiles(rofs, "*.ccs", SearchOption.AllDirectories))
                {
                    try
                    {
                        // Verifica se o arquivo começa com cabeçalho GZip (0x1F 0x8B)
                        using (FileStream fs = File.OpenRead(file))
                        {
                            byte[] header = new byte[2];
                            fs.Read(header, 0, 2);
                            if (header[0] != 0x1F || header[1] != 0x8B)
                            {
                                Console.WriteLine($"Ignorado (não é GZip): {file}");
                                continue;
                            }
                        }

                        MemoryStream ms = new MemoryStream();
                        GZipStream gzipStream = new GZipStream(new MemoryStream(File.ReadAllBytes(file)), CompressionMode.Decompress);
                        gzipStream.CopyTo(ms);
                        File.WriteAllBytes(file, ms.ToArray());

                        lblProgress.Text = $"Decompressing CVM files: {file}";
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro ao processar {file}: {ex.Message}");
                    }
                }

                MessageBox.Show("Game successfully extracted!");
            }
        }
        
        void ExtrairArquivos(CDReader cd, string cdPath, string destinoBase)
        {
            foreach (var dir in cd.GetDirectories(cdPath))
            {
                ExtrairArquivos(cd, dir, destinoBase);
            }

            foreach (var file in cd.GetFiles(cdPath))
            {
                string relativePath = file.TrimStart('\\');
                if (relativePath.EndsWith(";1"))
                    relativePath = relativePath.Substring(0, relativePath.Length - 2);
                string destino = Path.Combine(destinoBase, relativePath);

                Console.WriteLine("Extraindo: " + destino);
                Directory.CreateDirectory(Path.GetDirectoryName(destino));

                using (var source = cd.OpenFile(file, FileMode.Open))
                using (var dest = File.Create(destino))
                {
                    source.CopyTo(dest);
                }
            }
        }
    }
}