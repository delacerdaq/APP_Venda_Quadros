using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace APP_Venda_Quadros
{
    internal class Conexao
    {
        MySqlConnection conn;

        private void Conectar() // método que estabelece a conexão com o banco de dados
        {
            try
            {
                string conexao = "Persist Security Info = false; server = localhost; database = venda_quadros; user = root; pwd=;";
                conn = new MySqlConnection(conexao);
                conn.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("Verifique sua conexão com o BD.");
            }

        }

        public void ExecutarComando(string sql) //insert, update e delete
        {
            Conectar();
            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conn);
                comando.ExecuteNonQuery(); // intrução sql é executada no banco   
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na instrução SQL fornecida.");
            }
            finally
            {
                conn.Close();
            }

        }

        public DataTable ExecutarConsulta(string sql)
        {
            Conectar();

            try
            {
                MySqlDataAdapter query = new MySqlDataAdapter(sql, conn);
                DataTable dados = new DataTable();
                query.Fill(dados);
                return dados;
            }
            catch (Exception ex)
            {
                throw new Exception("Verifique a instrução SELECT fornecida.");
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
