using MySql.Data.MySqlClient;
using System.Data;

namespace DAL
{
    public class Conexao
    {
        private string conexao = "server=localhost;user=root; password=cursoads;database = bd_camadas";
        private MySqlConnection cnn;
        public bool Conectar()
        { 
            bool result = false;
            cnn = new MySqlConnection(conexao);
            try
            {
                cnn.Open();
                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return result;

        }
        public void Desconectar()
        {
            if (cnn.State == System.Data.ConnectionState.Open) cnn.Close();
        }
        public bool Executar(string sql)
        {
            bool result = false;
            Conectar();
            try
            {
                MySqlCommand comando = new MySqlCommand(sql, cnn);
                comando.ExecuteNonQuery();
                result= true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { Desconectar(); }
            return result;

        }

        public DataTable Pesquisar(string sql)
        {
            Conectar();
            try
            {
                MySqlCommand comando = new MySqlCommand(sql, cnn);
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = comando;
                DataTable tabela = new DataTable();
                da.Fill(tabela);
                return tabela;
            }
            catch(Exception ex)
            { 
                Console.WriteLine(ex.ToString());
                throw ex;
            }
            finally { Desconectar(); }
        }
    }
}