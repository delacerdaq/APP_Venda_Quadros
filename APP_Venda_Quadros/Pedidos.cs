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
    public partial class Pedidos : Form
    {
        public Pedidos()
        {
            InitializeComponent();
        }

        Conexao objBD = new Conexao();

        private void Limpar()
        {
            txtIdPedido.Clear();
            txtIdCliente.Clear();
            dtpPedido.Value = DateTime.Now;
            cmbStatus.Text = "";
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
                int IdPedido = int.Parse(txtIdPedido.Text);
                int IdCliente = int.Parse(txtIdCliente.Text);
                DateTime pedido = dtpPedido.Value;
                string status = cmbStatus.Text;

                //criar instrução de insert 
                string inserir = $"INSERT INTO pedidos VALUES('{IdPedido}', '{IdCliente}','{pedido}','{status}');";

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
                int IdPedido = int.Parse(txtIdPedido.Text);
                int IdCliente = int.Parse(txtIdCliente.Text);
                DateTime pedido = dtpPedido.Value;
                string status = cmbStatus.Text;

                //criar instrução de update
                string update = $"UPDATE pedidos SET id_pedido = '{IdPedido}', id_cliente = '{IdCliente}', data_pedido = '{pedido}', status_pedido = '{status}' WHERE id_pedido = '{IdPedido}';";

                objBD.ExecutarComando(update);
                Limpar();
                MessageBox.Show($"Dados do registro {IdPedido} alterados com sucesso.");
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
                int IdPedido = int.Parse(txtIdPedido.Text);

                //criar instrução de insert 
                string delete = $"DELETE FROM pedidos WHERE id_pedido = '{IdPedido}';";

                objBD.ExecutarComando(delete);
                Limpar();
                MessageBox.Show($"Dados do registro {IdPedido} excluídos com sucesso.");
                ExibirDadosNoGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ExibirDadosNoGrid()
        {
            string consulta = "SELECT * FROM pedidos ORDER BY id_pedido;";
            dtgPedidos.DataSource = objBD.ExecutarConsulta(consulta);
        }

        private void dtgPedidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIdPedido.Text = dtgPedidos.Rows[e.RowIndex].Cells["id_pedido"].Value.ToString();
            txtIdCliente.Text = dtgPedidos.Rows[e.RowIndex].Cells["id_cliente"].Value.ToString();
            dtpPedido.Value = DateTime.Parse(dtgPedidos.Rows[e.RowIndex].Cells["data_pedido"].Value.ToString());
            cmbStatus.Text = dtgPedidos.Rows[e.RowIndex].Cells["status_pedido"].Value.ToString();
        }

        private void Pedidos_Load(object sender, EventArgs e)
        {
            ExibirDadosNoGrid();
        }
    }
}
