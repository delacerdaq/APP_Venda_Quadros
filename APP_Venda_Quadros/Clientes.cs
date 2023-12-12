using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_Venda_Quadros
{
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
        }

        Conexao objBD = new Conexao();
        
        private void Limpar()
        {
            txtID.Clear();
            txtEmail.Clear();
            txtNome.Clear();
            txtTel.Clear();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                // armazenar em variáveis os valores digitados pelo usuário
                int ID = int.Parse(txtID.Text);
                string nome = txtNome.Text;
                string email = txtEmail.Text;
                string tel = txtTel.Text;

                //criar instrução de insert 
                string inserir = $"INSERT INTO clientes VALUES('{ID}', '{nome}','{email}','{tel}');";

                objBD.ExecutarComando(inserir);
                Limpar();
                MessageBox.Show("Dados Armazenados");
                ExibirDadosNoGrid();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                // armazenar em variáveis os valores digitados pelo usuário
                int ID = int.Parse(txtID.Text);
                string nome = txtNome.Text;
                string email = txtEmail.Text;
                string tel = txtTel.Text;

                //criar instrução de update
                string update = $"UPDATE clientes SET id_cliente = '{ID}', nome_cliente = '{nome}', email_cliente = '{email}', telefone_cliente = '{tel}' WHERE id_cliente = '{ID}';";

                objBD.ExecutarComando(update);
                Limpar();
                MessageBox.Show($"Dados do registro {ID} alterados com sucesso.");
                ExibirDadosNoGrid();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                // armazenar em variáveis os valores digitados pelo usuário
                int ID = int.Parse(txtID.Text);

                //criar instrução de insert 
                string delete = $"DELETE FROM clientes WHERE id_cliente = '{ID}';";

                objBD.ExecutarComando(delete);
                Limpar();
                MessageBox.Show($"Dados do registro {ID} excluídos com sucesso.");
                ExibirDadosNoGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ExibirDadosNoGrid()
        {
            string consulta = "SELECT * FROM clientes ORDER BY id_cliente;";
            dtgClientes.DataSource = objBD.ExecutarConsulta(consulta);
        }

        private void dtgClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dtgClientes.Rows[e.RowIndex].Cells["id_cliente"].Value.ToString();
            txtNome.Text = dtgClientes.Rows[e.RowIndex].Cells["nome_cliente"].Value.ToString();
            txtEmail.Text = dtgClientes.Rows[e.RowIndex].Cells["email_cliente"].Value.ToString();
            txtTel.Text = dtgClientes.Rows[e.RowIndex].Cells["telefone_cliente"].Value.ToString();
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            ExibirDadosNoGrid();
        }
    }
}
