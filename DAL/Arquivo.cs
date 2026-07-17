using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DAL
{
    internal class Arquivo
    {
        private string caminho = "c:\\arquivo.txt";
        public bool Gravar(string valor)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(caminho, true))
                {
                    sw.WriteLine(valor);
                }
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        public List<string> Ler()
        {
            List<string> dados = new List<string>();
            if (!File.Exists(caminho)) return dados;
            using (StreamReader sr = new StreamReader(caminho)) 
            {
                string linha;
                while((linha = sr.ReadLine()) != null){
                dados.Add(linha);
                }
            }
            return dados;
        }

        public bool Alterar(int id,string valor)
        {
            try
            {
                if (!File.Exists(caminho)) return false;
                List<string> linhas = File.ReadAllLines(caminho).ToList();
                for(int i = 0; i< linhas.Count; i++)
                {
                    string[] dados = linhas[i].Split(';');
                    if (Convert.ToInt32(dados[0])== id)
                    {
                        linhas[i] = valor;
                        break;
                    }
                }
                File.WriteAllLines(caminho, linhas);
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        public bool Excluir(int id)
        {
            try
            {
                if (!File.Exists(caminho)) return false;
                List<string> linhas = File.ReadAllLines (caminho).ToList();
                bool encontrou = false;
                for(int i=0; i<linhas.Count; i++)
                {
                    string[] dados = linhas[i].Split(';');
                    if (Convert.ToInt32(dados[0])==id)
                    {
                        linhas.RemoveAt(i);
                            encontrou = true;
                        return true;
                    }
                }
                if(encontrou)
                {
                    File.WriteAllLines(caminho, linhas);
                }
                return encontrou;

            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }

        }
    }
}
