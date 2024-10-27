﻿using System;
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
    public partial class GeneralParameters : Form
    {
        public GeneralParameters()
        {
            InitializeComponent();
        }
        public void VerifyOpenedELF(object sender, EventArgs e)
        {
            btnSaveELF.Enabled = Main.openedELF;
        }
        public void UpdateLabels(string charName, int charID)
        {
            lblCharName2.Text = charName;
            lblCharID2.Text = Convert.ToString(charID);
            Util.VerifyCurrentPlayersIDs();

            btnUpdateP1.Enabled = Main.P1ID == charID ? true : false;
            btnSaveELF.Enabled = Main.openedELF;
        }

        private void btnUpdateP1_Click(object sender, EventArgs e)
        {
            int charID = int.Parse(lblCharID2.Text);
            byte[] result = PlGen.UpdateCharGenPrm(this, charID);
            PlGen.UpdateP1GenPrm(result, charID);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            int charID = int.Parse(lblCharID2.Text);

            var charAtk = PlGen.CharGenPrmBkp[charID];
            PlGen.SendTextToGenForm(this, charAtk);
            byte[] result = PlGen.UpdateCharGenPrm(this, charID);
            PlGen.UpdateP1GenPrm(result, charID);
        }

        private void btnSaveELF_Click(object sender, EventArgs e)
        {
            int charID = int.Parse(lblCharID2.Text);
            byte[] result = PlGen.UpdateCharGenPrm(this, charID);
            PlGen.WriteELFCharPrm(result, charID);
        }
    }
}
