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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
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
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.portuguêsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEditMovesetParameters = new System.Windows.Forms.Button();
            this.picMainBackground = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMainBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // lblcharName
            // 
            this.lblcharName.AutoSize = true;
            this.lblcharName.Location = new System.Drawing.Point(232, 34);
            this.lblcharName.Name = "lblcharName";
            this.lblcharName.Size = new System.Drawing.Size(63, 13);
            this.lblcharName.TabIndex = 3;
            this.lblcharName.Text = "Char Name:";
            this.lblcharName.Visible = false;
            // 
            // txtcharName
            // 
            this.txtcharName.Location = new System.Drawing.Point(301, 31);
            this.txtcharName.Name = "txtcharName";
            this.txtcharName.ReadOnly = true;
            this.txtcharName.Size = new System.Drawing.Size(202, 20);
            this.txtcharName.TabIndex = 4;
            this.txtcharName.Visible = false;
            // 
            // txtCCSName
            // 
            this.txtCCSName.Location = new System.Drawing.Point(715, 31);
            this.txtCCSName.Name = "txtCCSName";
            this.txtCCSName.ReadOnly = true;
            this.txtCCSName.Size = new System.Drawing.Size(148, 20);
            this.txtCCSName.TabIndex = 5;
            this.txtCCSName.Visible = false;
            // 
            // lblCCSName
            // 
            this.lblCCSName.AutoSize = true;
            this.lblCCSName.Location = new System.Drawing.Point(647, 34);
            this.lblCCSName.Name = "lblCCSName";
            this.lblCCSName.Size = new System.Drawing.Size(62, 13);
            this.lblCCSName.TabIndex = 6;
            this.lblCCSName.Text = "CCS Name:";
            this.lblCCSName.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(235, 66);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(628, 269);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // btnEditGeneralParameters
            // 
            this.btnEditGeneralParameters.Location = new System.Drawing.Point(235, 352);
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
            this.lstChar.Location = new System.Drawing.Point(3, 31);
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
            this.languageToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(867, 24);
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
            this.changeCharacterToolStripMenuItem});
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
            this.changeCharacterToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
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
            // btnEditMovesetParameters
            // 
            this.btnEditMovesetParameters.Location = new System.Drawing.Point(387, 352);
            this.btnEditMovesetParameters.Name = "btnEditMovesetParameters";
            this.btnEditMovesetParameters.Size = new System.Drawing.Size(135, 23);
            this.btnEditMovesetParameters.TabIndex = 12;
            this.btnEditMovesetParameters.Text = "Edit Moveset Parameters";
            this.btnEditMovesetParameters.UseVisualStyleBackColor = true;
            this.btnEditMovesetParameters.Visible = false;
            this.btnEditMovesetParameters.Click += new System.EventHandler(this.btnEditMovesetParameters_Click);
            // 
            // picMainBackground
            // 
            this.picMainBackground.Image = global::UN5CharPrmEditor.Properties.Resources.MainBackground;
            this.picMainBackground.InitialImage = global::UN5CharPrmEditor.Properties.Resources.MainBackground;
            this.picMainBackground.Location = new System.Drawing.Point(0, 25);
            this.picMainBackground.Name = "picMainBackground";
            this.picMainBackground.Size = new System.Drawing.Size(867, 408);
            this.picMainBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picMainBackground.TabIndex = 13;
            this.picMainBackground.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 429);
            this.Controls.Add(this.picMainBackground);
            this.Controls.Add(this.btnEditMovesetParameters);
            this.Controls.Add(this.lstChar);
            this.Controls.Add(this.btnEditGeneralParameters);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblCCSName);
            this.Controls.Add(this.txtCCSName);
            this.Controls.Add(this.txtcharName);
            this.Controls.Add(this.lblcharName);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "UN5CharPrmEditor";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMainBackground)).EndInit();
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
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pCSX2MemoryProcessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openELFToolStripMenuItem;
        private System.Windows.Forms.Button btnEditMovesetParameters;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.PictureBox picMainBackground;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeCharacterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeP1CharacterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeP2CharacterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem portuguêsToolStripMenuItem;
    }
}

