using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UN5CharPrmEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class MovesetParameters : Form
    {
        public static int p1IDFromForm1;
        public Rectangle button;

        public MovesetParameters()
        {
            InitializeComponent();
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
        }
        public void VerifyOpenedELF(object sender, EventArgs e)
        {
            btnSaveELF.Enabled = Main.openedELF;
        }
        public void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int charID = int.Parse(lblCharID2.Text);
            int selectedIndex = listBox1.SelectedIndex;

            if (btnEditAtkParameters.Visible == false)
            {
                lblSelectedAtk2.Text = listBox1.SelectedIndex.ToString();

                CharAtk.SendTextAtk(this, CharAtk.GetCharAtk(charID, selectedIndex));
            }
            else
            {
                int selectedAnm = int.Parse(listBox1.SelectedItem.ToString().Split(':')[0]);
                CharAnm.SendTextAnm(this, CharAnm.GetCharAnm(charID, selectedAnm));
            }
        }

        public void UpdateLabels(string txtCharNameForm1, string charIDForm1)
        {
            lblCharName2.Text = txtCharNameForm1;
            lblCharID2.Text = charIDForm1;
            int.TryParse(charIDForm1, out int CharIDForm2Int);
            Util.VerifyCurrentPlayersIDs();

            p1IDFromForm1 = Main.P1ID;

            if (p1IDFromForm1 == CharIDForm2Int)
            {
                btnUpdateP1.Enabled = true;
            }
            if (Main.openedELF == true)
            {
                btnSaveELF.Enabled = true;
            }

            listBox1.SelectedIndex = 21;
        }

        private void btnUpdateP1_Click(object sender, EventArgs e)
        {
            if (btnEditAtkParameters.Visible == false)
            {
                int charID = int.Parse(lblCharID2.Text);
                int atkID = int.Parse(lblSelectedAtk2.Text);
                byte[] resultBytes = CharAtk.UpdateCharAtkPrm(this, charID, atkID);
                int selectedAtk = listBox1.SelectedIndex;
                CharAtk.UpdateP1Atk(resultBytes, selectedAtk);
            }
            else
            {
                int charID = int.Parse(lblCharID2.Text);
                byte[] resultBytes = CharAnm.UpdateCharAnmPrm(this, charID);
                int selectedAnm = int.Parse(listBox1.SelectedItem.ToString().Split(':')[0]);
                CharAnm.UpdateP1Anm(resultBytes, selectedAnm);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if(btnEditAtkParameters.Visible == false)
            {
                int charID = int.Parse(lblCharID2.Text);
                int selectedIndex = listBox1.SelectedIndex;
                var ninjaCharsAtkBkpList = CharAtk.CharAtkPrmBkp[charID][selectedIndex];
                CharAtk.SendTextAtk(this, ninjaCharsAtkBkpList);
            }
            else
            {
                int charID = int.Parse(lblCharID2.Text);
                int selectedAnm = int.Parse(listBox1.SelectedItem.ToString().Split(':')[0]);
                var ninjaCharsAnmBkpList = CharAnm.CharAnmPrmBkp[charID][selectedAnm];
                CharAnm.SendTextAnm(this, ninjaCharsAnmBkpList);
            }
        }

        private void btnSaveELF_Click(object sender, EventArgs e)
        {
            if (btnEditAtkParameters.Visible == false)
            {
                int charID = int.Parse(lblCharID2.Text);
                byte[] resultBytes = CharAtk.UpdateAllCharAtkPrm(this, charID);
                CharAtk.WriteELFCharAtk(resultBytes, charID);
            }
            else
            {
                int charID = int.Parse(lblCharID2.Text);
                byte[] resultBytes = CharAnm.UpdateAllCharAnmPrm(this, charID);
                CharAnm.WriteELFCharAnm(resultBytes, charID);
            }
        }

        private void btnEditAnmParameters_Click(object sender, EventArgs e)
        {
            pnlAtkPrm.Visible = false;
            pnlAnmPrm.Visible = true;
            listBox1.Items.Clear();
            btnEditAnmParameters.Visible = false;
            btnEditAtkParameters.Visible = true;
            AddToListBox();
            listBox1.SelectedIndex = 0;
        }

        private void AddToListBox()
        {
            int SelectedAtk = int.Parse(lblSelectedAtk2.Text);
            int currentCharID = int.Parse(lblCharID2.Text);

            int AtkAnmBlock = CharAtk.CharAtkPrm[currentCharID][SelectedAtk].AtkAnm;
            int MaxAnm = CharGen.CharGenPrm[currentCharID].AnmCount;

            for (int i = AtkAnmBlock; i < MaxAnm; i++)
            {
                int AnmID = CharAnm.GetCharAnm(currentCharID, i).AnmID;

                if (-1 != AnmID)
                {
                    listBox1.Items.Add($"{i}: {CharAnm.GetCharAnmName(currentCharID, AnmID)}");
                }
                else
                {
                    break;
                }
            }
        }

        private void btnEditAtkParameters_Click(object sender, EventArgs e)
        {
            pnlAnmPrm.Visible = false;
            pnlAtkPrm.Visible = true;
            listBox1.Items.Clear();
            int currentCharID = int.Parse(lblCharID2.Text);
            string currentCharName = lblCharName2.Text;
            CharAtk.AddCharComboList(this, currentCharID, currentCharName);
            listBox1.SelectedIndex = int.Parse(lblSelectedAtk2.Text);
        }
    }
}
