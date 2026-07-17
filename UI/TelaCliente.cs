using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto3Camadas
{
    public partial class TelaCliente : Form
    {
        public TelaCliente()
        {
            InitializeComponent();
        }
        Cliente cli;
        private void TelaCliente_Load(object sender, EventArgs e)
        {
            cli = new Cliente();
            dataGridView1.DataSource = cli.Listar();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            cli = new Cliente();
            cli.Id = Convert.ToInt32(txtId.Text);
            cli.Nome = txtNome.Text;
            cli.Cpf = txtCpf.Text;
            cli.Endereco = txtEndereco.Text;
            MessageBox.Show(cli.Salvar() ? "Cadastrado com sucesso" :
                "não foi possivel Cadastar!");
            limpar();
            dataGridView1.DataSource = cli.Listar();

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            cli = new Cliente();
            cli.Id = Convert.ToInt32(txtId.Text);
            cli.Nome = txtNome.Text;
            cli.Cpf = txtCpf.Text;
            cli.Endereco = txtEndereco.Text;
            MessageBox.Show(cli.Editar() ? "Editado com sucesso" :
                "não foi possivel Editar!");
            limpar();
            dataGridView1.DataSource = cli.Listar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            cli = new Cliente();
            cli.Id = Convert.ToInt32(txtId.Text);
            MessageBox.Show(cli.Excluir() ? "Excluido com sucesso" :
                "não foi possivel Excluir!");
            limpar();
            dataGridView1.DataSource = cli.Listar();

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            cli = new Cliente();
            cli.Id = Convert.ToInt32(txtId.Text);
            DataRow linha = cli.BuscarId();
            if(linha != null)
            {
                txtNome.Text = linha["NOME"].ToString();
                txtCpf.Text = linha["CPF"].ToString();
                txtEndereco.Text = linha["ENDEREÇO"].ToString();
            }
            else
            {
                MessageBox.Show("Cliente não foi encontrado!");
                limpar();
                dataGridView1.DataSource = cli.Listar();
            }
        }
        public void limpar()
        {
            txtCpf.Text = null;
            txtEndereco.Text = null;
            txtId.Text = null;
            txtNome.Text = null;
        }
    }
}
