using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        // Manipulador de eventos para o clique em um item da ListBox
        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifique se um item está selecionado
            if (ListBox1.SelectedItem != null)
            {
                // Obtenha o processo selecionado na ListBox
                ProcessDetails selectedProcess = (ProcessDetails)ListBox1.SelectedItem;

                // Obtenha o ID do processo selecionado
                int selectedProcessId = selectedProcess.Id;

                // Faça o que você precisa com o ID do processo, como armazená-lo em uma variável
                // Por exemplo:
                int idDoProcessoSelecionado = selectedProcessId;

                form1Instance.SelectedProcess(idDoProcessoSelecionado);

                this.Close();
            }
        }

        public void AdicionarItemListBox(object item)
        {
            // Adicione o item à ListBox
            listBox1.Items.Add(item);
        }
    }
}
