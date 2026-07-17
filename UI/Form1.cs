
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace Projeto3Camadas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Fornecedor forn; 
        private void Form1_Load(object sender,EventArgs e)
        {
            forn = new Fornecedor();
            dataGridView1.DataSource = forn.PesquisarTodos();
        }

      

        private void btnCdastrar_Click(object sender, EventArgs e)
        {
            forn = new Fornecedor();
            forn.Id = Convert.ToInt32(txtId.Text);
            forn.Razao = txtRazao.Text;
            forn.Cnpj = txtCnpj.Text;
            forn.Email = txtEmail.Text;
            MessageBox.Show(forn.Salvar() ? "Cadastrar com sucesso!" :
                "não foi possivel cadastrar!");

            Form1_Load(sender, e);
            limpar();
        }
        
        private void limpar()
        {
            txtId.Text = null;
            txtRazao.Text = null;
            txtCnpj.Text = null;
            txtEmail.Text = null;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            forn = new Fornecedor();
            forn.Id = Convert.ToInt32(txtId.Text);
            txtRazao.Text =txtRazao.Text ;
            txtCnpj.Text = txtCnpj.Text;
            txtEmail.Text = txtEmail.Text;
            MessageBox.Show(forn.Atualizar() ? "atualizado com sucesso!" :
                "não foi possivelk Atualizar!");
            Form1_Load(sender, e);
            limpar();

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            forn = new Fornecedor();
            forn.Id = Convert.ToInt32(txtId.Text);
            MessageBox.Show(forn.Excluir() ? "excluido com suvcesso!" :
                "nao foi possivel escluir");
            Form1_Load(sender, e);
            limpar();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            forn = new Fornecedor();
            forn.Id = Convert.ToInt32(txtId.Text);
            DataTable dt = forn.Pesquisar();
            txtRazao.Text = dt.Rows[0]["razao"].ToString();
            txtCnpj.Text = dt.Rows[0]["cnpj"].ToString();
            txtEmail.Text = dt.Rows[0]["email"].ToString(); 
        }
    }
}
