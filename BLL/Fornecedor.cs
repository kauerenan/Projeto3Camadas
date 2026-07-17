using DAL;
using MySql.Data.MySqlClient;
using System.Data;
namespace BLL
{
    public class Fornecedor
    {
        public int Id {get;set;}
        public string Razao {get;set;}
        public string Cnpj { get;set;}
        public string Email { get;set;}

        Conexao con;
        public bool Salvar()
        {
            con = new Conexao();
            string salvar = $"insert into fornecedor values ({Id}," +
                $"'{Razao}', '{Cnpj}', '{Email}');";

            return con.Executar(salvar);
        }
        public bool Atualizar()
        {
            con = new Conexao();
            string alterar = $"update fornecedor set razao='{Razao}'" +
                $", cnpj='{Cnpj}' email='{Email}' where id='{Id};";
            return con.Executar(alterar);
        }

        public bool Excluir()
        {
            con = new Conexao();
            string apagar = $"delete from fornecedor where id={Id};";
            return con.Executar(apagar);
        }

        public DataTable PesquisarTodos()
        {

            DataTable dt = new DataTable();
            con = new Conexao();
            string todos = "select * from fornecedor;";
            dt = con.Pesquisar(todos);
            return dt;
        }

        public DataTable Pesquisar()
        {

            DataTable dt = new DataTable();
            con = new Conexao();
            string todos = $"select * from fornecedor where id={Id};";
            dt = con.Pesquisar(todos);
            return dt;
        }



    }
}