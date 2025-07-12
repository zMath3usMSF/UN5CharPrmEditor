using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace UN5CharPrmEditor
{
    public static class Config
    {
        public static void ReadConfigFile(Main form)
        {
            List<string> fileCfg = new List<string>();
            if (!File.Exists(@"config.txt"))
            {
                fileCfg.Add("theme=default");
                File.WriteAllLines(@"config.txt", fileCfg.ToArray());
            }
            fileCfg = File.ReadAllLines(@"config.txt").ToList();
            foreach (string line in fileCfg)
            {
                string parameter = line.Split('=')[0];
                if (parameter == "theme")
                {
                    switch (line.Split('=')[0])
                    {
                        case "white":
                            form.whiteToolStripMenuItem.Checked = true;
                            break;
                        case "black":
                            form.blackToolStripMenuItem.Checked = true;
                            break;
                        default:
                            form.defaultToolStripMenuItem.Checked = true;
                            break;
                    }
                }
            }
        }

        public static void ChangedTheme(Main form, string theme)
        {
            form.defaultToolStripMenuItem.Checked = false;
            form.whiteToolStripMenuItem.Checked = false;
            form.blackToolStripMenuItem.Checked = false;
            switch (theme)
            {
                case "white":
                    form.whiteToolStripMenuItem.Checked = true;
                    break;
                case "black":
                    // Cor base do modo escuro
                    Color fundoEscuro = Color.FromArgb(30, 30, 30);
                    Color textoBranco = Color.White;

                    // Formulário inteiro
                    
                    form.BackColor = fundoEscuro;
                    form.ForeColor = textoBranco;

                    // MenuStrip
                    form.menuStrip1.Renderer = new ToolStripProfessionalRenderer(new DarkColorTable());
                    form.menuStrip1.BackColor = fundoEscuro;
                    form.menuStrip1.ForeColor = textoBranco;

                    // Você pode repetir isso para outros controles (opcional)
                    foreach (Control ctrl in form.Controls)
                    {
                        ctrl.BackColor = fundoEscuro;
                        ctrl.ForeColor = textoBranco;
                    }
                    form.blackToolStripMenuItem.Checked = true;
                    break;
                default:
                    form.defaultToolStripMenuItem.Checked = true;
                    break;
            }
        }
        public class DarkColorTable : ProfessionalColorTable
        {
            public override Color MenuBorder => Color.FromArgb(45, 45, 45);
            public override Color ToolStripDropDownBackground => Color.FromArgb(30, 30, 30);
            public override Color MenuItemSelected => Color.FromArgb(70, 70, 70);
            public override Color MenuItemBorder => Color.FromArgb(70, 70, 70);
            public override Color MenuItemSelectedGradientBegin => Color.FromArgb(60, 60, 60);
            public override Color MenuItemSelectedGradientEnd => Color.FromArgb(60, 60, 60);
            public override Color MenuItemPressedGradientBegin => Color.FromArgb(50, 50, 50);
            public override Color MenuItemPressedGradientEnd => Color.FromArgb(50, 50, 50);
        }
    }
}
