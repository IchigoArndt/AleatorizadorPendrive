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
using TelaAleatorizador.Infra;

namespace TelaAleatorizador.Apresentacao
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
            btnIniciar.Enabled = false;
        }

        bool IsValid = false;

        codigoBruto cb = new codigoBruto();

        public bool PathIsValid(DirectoryInfo Path, DirectoryInfo PathExit)
        {
            if(!Path.Exists && PathExit.Exists)
            {
                MessageBox.Show("Caminho De Entrada Invalido");
                IsValid = false;
                return IsValid;
            }

            if(Path.Exists && !PathExit.Exists)
            {
                MessageBox.Show("Caminho De Saida Invalido");
                IsValid = false;
                return IsValid;
            }

            if (!Path.Exists && !PathExit.Exists)
            {
                MessageBox.Show("Os Caminhos Estão Invalidos");
                IsValid =  false;
                return IsValid;
            }

            if (Path.FullName.Equals(PathExit.FullName))
            {
                MessageBox.Show("Os Caminhos Não podem ser iguais");
                IsValid =  false;
                return IsValid;
            }

            if (PathExit.FullName.Equals(Path.FullName))
            {
                MessageBox.Show("Os Caminhos Não podem ser iguais");
                IsValid =  false;
                return IsValid;
            }

            if (Path.Exists && PathExit.Exists)
                IsValid =  true;

            return IsValid;
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            string caminhoEntrada = txtEntrada.Text;
            string caminhoSaida = txtSaida.Text;

            DirectoryInfo di = new DirectoryInfo(caminhoEntrada);
            DirectoryInfo ds = new DirectoryInfo(caminhoSaida);

            bool isValid = PathIsValid(di, ds);

            if (isValid)
                btnIniciar.Enabled = true;
            else
                btnIniciar.Enabled = false;
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            List<FileInfo> ListaMusica = new List<FileInfo>();
            ListaMusica = cb.GetFile(txtEntrada.Text.ToString());
            cb.RenameFiles(ListaMusica, txtSaida.Text.ToString());
            MessageBox.Show("Pronto !");
        }

        private void btnEntrada_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openFileDialog1 = new FolderBrowserDialog
            {
                Description = "Selecione a Pasta de entrada das Musicas"
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtEntrada.Text = openFileDialog1.SelectedPath;
            }

            //txtQtd.Text = cb.ReturnQuantFiles(txtEntrada.Text.ToString()).ToString();
        }

        private void btnSaida_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openFileDialog1 = new FolderBrowserDialog
            {
                Description = "Selecione a Pasta de saida para as Musicas"
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtSaida.Text = openFileDialog1.SelectedPath;
            }
        }
    }
}
