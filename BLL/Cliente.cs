using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;


namespace BLL
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf {get; set; }
        public string Endereco { get; set; }

        Arquivo arquivo;
        public bool Salvar()
        {
            arquivo = new DAL.Arquivo();
            string texto = $"{Id}; {Nome};{Cpf}; {Endereco}";
            return arquivo.Gravar(texto);

        }
        public DataTable Listar()
        {
            arquivo = new DAL.Arquivo();
            DataTable dt = new DataTable();
            List<string> lista = arquivo.Ler();
            dt.Columns.Add("Id");
            dt.Columns.Add("NOME");
            dt.Columns.Add("CPF");
            dt.Columns.Add("ENDERECO");
            foreach(string linhas in lista)
            {
                string[] dados = linhas.Split(';');
                if(dados.Length >= 4)
                {
                    dt.Rows.Add(dados[0], dados[1], dados[2], dados[3]);
                }
            }
            return dt;
        }
        public DataRow BuscarId()
        {
            DataTable dt = Listar();
            foreach(DataRow row in dt.Rows)
            {
                if (row["ID"].ToString().Equals(Id.ToString()))
                {
                    return row;
                }
            }
            return null;
        }
        public bool Editar()
        {
            arquivo = new Arquivo();
            string texto = $"{Id};{Nome};{Cpf};{Endereco}";
            return arquivo.Alterar(Id, texto);

        }
        public bool Excluir()
        {
            arquivo = new Arquivo();
            return arquivo.Excluir(Id);
        }
    }
}
