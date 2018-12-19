using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TelaAleatorizador.Apresentacao
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
            btnIniciar.Enabled = false;
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            string caminhoEntrada = txtEntrada.Text;
            string caminhoSaida = txtSaida.Text;

            DirectoryInfo di = new DirectoryInfo(caminhoEntrada);
            DirectoryInfo ds = new DirectoryInfo(caminhoSaida);
            if(di.Exists && ds.Exists)
            {
                if(di != ds)
                {
                    MessageBox.Show("Caminhos Invalidos");
                }
                else
                {
                    MessageBox.Show("Caminho Validos");
                    btnIniciar.Enabled = true;
                }
            }else
            {
                MessageBox.Show("Caminhos Invalidos");
            }
        }
    }
}
