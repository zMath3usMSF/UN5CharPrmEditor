namespace WindowsFormsApp1
{
    partial class Main
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.lblcharName = new System.Windows.Forms.Label();
            this.txtcharName = new System.Windows.Forms.TextBox();
            this.txtCCSName = new System.Windows.Forms.TextBox();
            this.lblCCSName = new System.Windows.Forms.Label();
            this.btnEditGeneralParameters = new System.Windows.Forms.Button();
            this.lstChar = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pCSX2MemoryProcessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openELFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeCharacterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeP1CharacterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeP2CharacterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewCharacterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractCVMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.portuguêsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.themeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.whiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEditMovesetParameters = new System.Windows.Forms.Button();
            this.btnEditAwekeningParameters = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnEditJutsusParameters = new System.Windows.Forms.Button();
            this.picMainBackground = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.picArrowRight = new System.Windows.Forms.PictureBox();
            this.picArrowLeft = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnSelectGamePath = new System.Windows.Forms.Button();
            this.txtGamePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblProgress = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMainBackground)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picArrowRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picArrowLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblcharName
            // 
            this.lblcharName.AutoSize = true;
            this.lblcharName.Location = new System.Drawing.Point(229, 9);
            this.lblcharName.Name = "lblcharName";
            this.lblcharName.Size = new System.Drawing.Size(63, 13);
            this.lblcharName.TabIndex = 3;
            this.lblcharName.Text = "Char Name:";
            this.lblcharName.Visible = false;
            // 
            // txtcharName
            // 
            this.txtcharName.Location = new System.Drawing.Point(298, 6);
            this.txtcharName.Name = "txtcharName";
            this.txtcharName.ReadOnly = true;
            this.txtcharName.Size = new System.Drawing.Size(202, 20);
            this.txtcharName.TabIndex = 4;
            this.txtcharName.Visible = false;
            // 
            // txtCCSName
            // 
            this.txtCCSName.Location = new System.Drawing.Point(712, 6);
            this.txtCCSName.Name = "txtCCSName";
            this.txtCCSName.ReadOnly = true;
            this.txtCCSName.Size = new System.Drawing.Size(148, 20);
            this.txtCCSName.TabIndex = 5;
            this.txtCCSName.Visible = false;
            // 
            // lblCCSName
            // 
            this.lblCCSName.AutoSize = true;
            this.lblCCSName.Location = new System.Drawing.Point(644, 9);
            this.lblCCSName.Name = "lblCCSName";
            this.lblCCSName.Size = new System.Drawing.Size(62, 13);
            this.lblCCSName.TabIndex = 6;
            this.lblCCSName.Text = "CCS Name:";
            this.lblCCSName.Visible = false;
            // 
            // btnEditGeneralParameters
            // 
            this.btnEditGeneralParameters.Location = new System.Drawing.Point(250, 316);
            this.btnEditGeneralParameters.Name = "btnEditGeneralParameters";
            this.btnEditGeneralParameters.Size = new System.Drawing.Size(129, 23);
            this.btnEditGeneralParameters.TabIndex = 8;
            this.btnEditGeneralParameters.Text = "Edit General Parameters";
            this.btnEditGeneralParameters.UseVisualStyleBackColor = true;
            this.btnEditGeneralParameters.Visible = false;
            this.btnEditGeneralParameters.Click += new System.EventHandler(this.btnEditGeneralParameters_Click);
            // 
            // lstChar
            // 
            this.lstChar.FormattingEnabled = true;
            this.lstChar.Location = new System.Drawing.Point(0, 0);
            this.lstChar.Name = "lstChar";
            this.lstChar.Size = new System.Drawing.Size(226, 394);
            this.lstChar.TabIndex = 10;
            this.lstChar.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.languageToolStripMenuItem,
            this.optionsToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(863, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pCSX2MemoryProcessToolStripMenuItem,
            this.openELFToolStripMenuItem});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // pCSX2MemoryProcessToolStripMenuItem
            // 
            this.pCSX2MemoryProcessToolStripMenuItem.Name = "pCSX2MemoryProcessToolStripMenuItem";
            this.pCSX2MemoryProcessToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.pCSX2MemoryProcessToolStripMenuItem.Text = "PCSX2 Memory Process";
            this.pCSX2MemoryProcessToolStripMenuItem.Click += new System.EventHandler(this.pCSX2MemoryProcessToolStripMenuItem_Click);
            // 
            // openELFToolStripMenuItem
            // 
            this.openELFToolStripMenuItem.Name = "openELFToolStripMenuItem";
            this.openELFToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.openELFToolStripMenuItem.Text = "ELF";
            this.openELFToolStripMenuItem.Click += new System.EventHandler(this.openELFToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeCharacterToolStripMenuItem,
            this.addNewCharacterToolStripMenuItem,
            this.extractCVMToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.optionsToolStripMenuItem.Text = "Util";
            // 
            // changeCharacterToolStripMenuItem
            // 
            this.changeCharacterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeP1CharacterToolStripMenuItem,
            this.changeP2CharacterToolStripMenuItem});
            this.changeCharacterToolStripMenuItem.Name = "changeCharacterToolStripMenuItem";
            this.changeCharacterToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.changeCharacterToolStripMenuItem.Text = "Change Character";
            // 
            // changeP1CharacterToolStripMenuItem
            // 
            this.changeP1CharacterToolStripMenuItem.Name = "changeP1CharacterToolStripMenuItem";
            this.changeP1CharacterToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.changeP1CharacterToolStripMenuItem.Text = "Change P1 Character";
            this.changeP1CharacterToolStripMenuItem.Click += new System.EventHandler(this.changeP1CharacterToolStripMenuItem_Click);
            // 
            // changeP2CharacterToolStripMenuItem
            // 
            this.changeP2CharacterToolStripMenuItem.Name = "changeP2CharacterToolStripMenuItem";
            this.changeP2CharacterToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.changeP2CharacterToolStripMenuItem.Text = "Change P2 Character";
            this.changeP2CharacterToolStripMenuItem.Click += new System.EventHandler(this.changeP2CharacterToolStripMenuItem_Click);
            // 
            // addNewCharacterToolStripMenuItem
            // 
            this.addNewCharacterToolStripMenuItem.Name = "addNewCharacterToolStripMenuItem";
            this.addNewCharacterToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.addNewCharacterToolStripMenuItem.Text = "Add New Character";
            this.addNewCharacterToolStripMenuItem.Click += new System.EventHandler(this.addNewCharacterToolStripMenuItem_Click);
            // 
            // extractCVMToolStripMenuItem
            // 
            this.extractCVMToolStripMenuItem.Name = "extractCVMToolStripMenuItem";
            this.extractCVMToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.extractCVMToolStripMenuItem.Text = "Extract Game";
            this.extractCVMToolStripMenuItem.Click += new System.EventHandler(this.extractCVMToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.CheckOnClick = true;
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem,
            this.portuguêsToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            this.languageToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.languageToolStripMenuItem.Text = "Language";
            this.languageToolStripMenuItem.Visible = false;
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.CheckOnClick = true;
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.englishToolStripMenuItem.Text = "English";
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // portuguêsToolStripMenuItem
            // 
            this.portuguêsToolStripMenuItem.CheckOnClick = true;
            this.portuguêsToolStripMenuItem.Name = "portuguêsToolStripMenuItem";
            this.portuguêsToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.portuguêsToolStripMenuItem.Text = "Português";
            this.portuguêsToolStripMenuItem.Click += new System.EventHandler(this.portuguêsToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem1
            // 
            this.optionsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.themeToolStripMenuItem});
            this.optionsToolStripMenuItem1.Name = "optionsToolStripMenuItem1";
            this.optionsToolStripMenuItem1.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem1.Text = "Options";
            this.optionsToolStripMenuItem1.Visible = false;
            // 
            // themeToolStripMenuItem
            // 
            this.themeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.defaultToolStripMenuItem,
            this.blackToolStripMenuItem,
            this.whiteToolStripMenuItem});
            this.themeToolStripMenuItem.Name = "themeToolStripMenuItem";
            this.themeToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.themeToolStripMenuItem.Text = "Theme";
            // 
            // defaultToolStripMenuItem
            // 
            this.defaultToolStripMenuItem.Name = "defaultToolStripMenuItem";
            this.defaultToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.defaultToolStripMenuItem.Text = "Default";
            // 
            // blackToolStripMenuItem
            // 
            this.blackToolStripMenuItem.Name = "blackToolStripMenuItem";
            this.blackToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.blackToolStripMenuItem.Text = "Black";
            // 
            // whiteToolStripMenuItem
            // 
            this.whiteToolStripMenuItem.Name = "whiteToolStripMenuItem";
            this.whiteToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.whiteToolStripMenuItem.Text = "White";
            // 
            // btnEditMovesetParameters
            // 
            this.btnEditMovesetParameters.Location = new System.Drawing.Point(400, 316);
            this.btnEditMovesetParameters.Name = "btnEditMovesetParameters";
            this.btnEditMovesetParameters.Size = new System.Drawing.Size(135, 23);
            this.btnEditMovesetParameters.TabIndex = 12;
            this.btnEditMovesetParameters.Text = "Edit Moveset Parameters";
            this.btnEditMovesetParameters.UseVisualStyleBackColor = true;
            this.btnEditMovesetParameters.Visible = false;
            this.btnEditMovesetParameters.Click += new System.EventHandler(this.btnEditMovesetParameters_Click);
            // 
            // btnEditAwekeningParameters
            // 
            this.btnEditAwekeningParameters.Location = new System.Drawing.Point(555, 316);
            this.btnEditAwekeningParameters.Name = "btnEditAwekeningParameters";
            this.btnEditAwekeningParameters.Size = new System.Drawing.Size(151, 23);
            this.btnEditAwekeningParameters.TabIndex = 14;
            this.btnEditAwekeningParameters.Text = "Edit Awekeninng Parameters";
            this.btnEditAwekeningParameters.UseVisualStyleBackColor = true;
            this.btnEditAwekeningParameters.Visible = false;
            this.btnEditAwekeningParameters.Click += new System.EventHandler(this.btnEditAwekeningParameters_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(232, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(628, 269);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // btnEditJutsusParameters
            // 
            this.btnEditJutsusParameters.Location = new System.Drawing.Point(727, 316);
            this.btnEditJutsusParameters.Name = "btnEditJutsusParameters";
            this.btnEditJutsusParameters.Size = new System.Drawing.Size(123, 23);
            this.btnEditJutsusParameters.TabIndex = 15;
            this.btnEditJutsusParameters.Text = "Edit Jutsus Parameters";
            this.btnEditJutsusParameters.UseVisualStyleBackColor = true;
            this.btnEditJutsusParameters.Visible = false;
            this.btnEditJutsusParameters.Click += new System.EventHandler(this.button1_Click);
            // 
            // picMainBackground
            // 
            this.picMainBackground.Image = global::UN5CharPrmEditor.Properties.Resources.MainBackground;
            this.picMainBackground.InitialImage = global::UN5CharPrmEditor.Properties.Resources.MainBackground;
            this.picMainBackground.Location = new System.Drawing.Point(-4, 0);
            this.picMainBackground.Name = "picMainBackground";
            this.picMainBackground.Size = new System.Drawing.Size(867, 380);
            this.picMainBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picMainBackground.TabIndex = 14;
            this.picMainBackground.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(863, 402);
            this.tabControl1.TabIndex = 16;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.picArrowRight);
            this.tabPage1.Controls.Add(this.picArrowLeft);
            this.tabPage1.Controls.Add(this.pictureBox2);
            this.tabPage1.Controls.Add(this.btnSelectGamePath);
            this.tabPage1.Controls.Add(this.txtGamePath);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.pictureBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(855, 376);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // picArrowRight
            // 
            this.picArrowRight.Location = new System.Drawing.Point(847, 311);
            this.picArrowRight.Name = "picArrowRight";
            this.picArrowRight.Size = new System.Drawing.Size(10, 14);
            this.picArrowRight.TabIndex = 6;
            this.picArrowRight.TabStop = false;
            // 
            // picArrowLeft
            // 
            this.picArrowLeft.Location = new System.Drawing.Point(-2, 311);
            this.picArrowLeft.Name = "picArrowLeft";
            this.picArrowLeft.Size = new System.Drawing.Size(10, 14);
            this.picArrowLeft.TabIndex = 5;
            this.picArrowLeft.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(9, 322);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(38, 46);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // btnSelectGamePath
            // 
            this.btnSelectGamePath.Location = new System.Drawing.Point(825, 6);
            this.btnSelectGamePath.Name = "btnSelectGamePath";
            this.btnSelectGamePath.Size = new System.Drawing.Size(28, 23);
            this.btnSelectGamePath.TabIndex = 2;
            this.btnSelectGamePath.Text = "...";
            this.btnSelectGamePath.UseVisualStyleBackColor = true;
            this.btnSelectGamePath.Click += new System.EventHandler(this.btnSelectGamePath_Click);
            // 
            // txtGamePath
            // 
            this.txtGamePath.Location = new System.Drawing.Point(456, 8);
            this.txtGamePath.Name = "txtGamePath";
            this.txtGamePath.ReadOnly = true;
            this.txtGamePath.Size = new System.Drawing.Size(363, 20);
            this.txtGamePath.TabIndex = 1;
            this.txtGamePath.TextChanged += new System.EventHandler(this.txtGamePath_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(387, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Game Path:";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(319, 34);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(252, 243);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.picMainBackground);
            this.tabPage2.Controls.Add(this.lstChar);
            this.tabPage2.Controls.Add(this.pictureBox1);
            this.tabPage2.Controls.Add(this.btnEditJutsusParameters);
            this.tabPage2.Controls.Add(this.lblCCSName);
            this.tabPage2.Controls.Add(this.btnEditAwekeningParameters);
            this.tabPage2.Controls.Add(this.txtCCSName);
            this.tabPage2.Controls.Add(this.btnEditMovesetParameters);
            this.tabPage2.Controls.Add(this.btnEditGeneralParameters);
            this.tabPage2.Controls.Add(this.lblcharName);
            this.tabPage2.Controls.Add(this.txtcharName);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(855, 376);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblProgress);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 423);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(863, 15);
            this.panel1.TabIndex = 17;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblProgress.Location = new System.Drawing.Point(853, 0);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(10, 13);
            this.lblProgress.TabIndex = 0;
            this.lblProgress.Text = ".";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 438);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "UN5CharPrmEditor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMainBackground)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picArrowRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picArrowLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblcharName;
        private System.Windows.Forms.TextBox txtcharName;
        private System.Windows.Forms.TextBox txtCCSName;
        private System.Windows.Forms.Label lblCCSName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnEditGeneralParameters;
        private System.Windows.Forms.ListBox lstChar;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pCSX2MemoryProcessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openELFToolStripMenuItem;
        private System.Windows.Forms.Button btnEditMovesetParameters;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeCharacterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeP1CharacterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeP2CharacterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem portuguêsToolStripMenuItem;
        private System.Windows.Forms.Button btnEditAwekeningParameters;
        private System.Windows.Forms.Button btnEditJutsusParameters;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem themeToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem defaultToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem blackToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem whiteToolStripMenuItem;
        public System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.PictureBox picMainBackground;
        private System.Windows.Forms.ToolStripMenuItem addNewCharacterToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSelectGamePath;
        private System.Windows.Forms.TextBox txtGamePath;
        public System.Windows.Forms.TabControl tabControl1;
        public System.Windows.Forms.PictureBox pictureBox2;
        public System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.PictureBox pictureBox3;
        public System.Windows.Forms.PictureBox picArrowLeft;
        public System.Windows.Forms.PictureBox picArrowRight;
        private System.Windows.Forms.ToolStripMenuItem extractCVMToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label lblProgress;
    }
}

