using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace UN5CharPrmEditor
{
    public partial class UpdateMatch : Form
    {
        Main mainInstance = new Main();
        public UpdateMatch(Main main)
        {
            InitializeComponent();
            mainInstance = main;
        }

        public void SendText(bool isP1)
        {
            IntPtr processHandle = Main.OpenProcess(Main.PROCESS_ALL_ACCESS, false, Main.currentProcessID);
            if (processHandle != IntPtr.Zero)
            {
                byte[] PlayerIDByte = new byte[1];
                IntPtr PlayerOffset = (IntPtr)(isP1 == true ? Main.isNA2 == true ? 0x20C416FC : 0x20BD7AAC  + Main.memoryDif : Main.isNA2 == true ? 0x20C41724 : 0x20BD7AD4  + Main.memoryDif);
                Main.ReadProcessMemory(processHandle, PlayerOffset, PlayerIDByte, PlayerIDByte.Length, out var none4);

                if (cmbCharList.Items.Count == 0)
                {
                    for (int i = 0; i <= 93; i++)
                    {
                        if (!Main.charInvalid.Contains(i))
                        {
                            cmbCharList.Items.Add($"{i}: {Main.charName[i]}");
                        }
                    }
                }
                int PlayerID = PlayerIDByte[0];
                for(int i = 0; i < cmbCharList.Items.Count; i++)
                {
                    string[] teste = cmbCharList.Items[i].ToString().Split(':');
                    if (teste[0] == PlayerID.ToString())
                    {
                        cmbCharList.SelectedIndex = i;
                    }
                }

                byte[] MapIDByte = new byte[1];
                Main.ReadProcessMemory(processHandle, Main.isNA2 == true ? (IntPtr)0x20C41748: (IntPtr)0x20BD7AF8 + Main.memoryDif, MapIDByte, MapIDByte.Length, out var none5);
                int MapID = MapIDByte[0];

                if (cmbMapList.Items.Count == 0)
                {
                    for (int i = 0; i < 24; i++)
                    {
                        cmbMapList.Items.Add($"{i}: " + Main.GetMapName(i));
                    }
                }
                cmbMapList.SelectedIndex = MapID;

                Main.CloseHandle(processHandle);
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            bool isP1;
            string[] PlayerIDString = cmbCharList.SelectedItem.ToString().Split(':');
            int PlayerID = int.Parse(PlayerIDString[0]);
            int MapID = cmbMapList.SelectedIndex;

            isP1 = lblPlayerID.Text == "P1:" ? true : false;

            mainInstance.UpdateMatch(isP1, PlayerID, MapID);
        }
    }
}
