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
    public partial class Detalhes_Pedido : Form
    {
        public Detalhes_Pedido()
        {
            InitializeComponent();
        }

        Conexao objBD = new Conexao();
        private void Limpar()
        {
            txtIdDetalhe.Clear();
            txtIdPedido.Clear();
            txtIdQuadro.Clear();
            txtPrecoUnit.Clear();
            txtQuant.Clear();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                int IdDetalhe = int.Parse(txtIdDetalhe.Text);
                int IdPedido = int.Parse(txtIdPedido.Text);
                int IdQuadro = int.Parse(txtIdQuadro.Text);
                int quant = int.Parse(txtQuant.Text);
                double preco = double.Parse(txtPrecoUnit.Text);

                string inserir = $"INSERT INTO detalhes_pedido VALUES ('{IdDetalhe}','{IdPedido}','{IdQuadro}','{quant}','{preco}')";

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
                int IdDetalhe = int.Parse(txtIdDetalhe.Text);
                int IdPedido = int.Parse(txtIdPedido.Text);
                int IdQuadro = int.Parse(txtIdQuadro.Text);
                int quant = int.Parse(txtQuant.Text);
                double preco = double.Parse(txtPrecoUnit.Text);

                string update = $"UPDATE detalhes_pedido SET id_detalhe = '{IdDetalhe}', id_pedido = '{IdPedido}', id_quadro = '{IdQuadro}', quantidade = '{quant}', preco_unitario = '{preco}' WHERE id_detalhe = '{IdDetalhe}';";

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
                int IdDetalhe = int.Parse(txtIdDetalhe.Text);

                //criar instrução de insert 
                string delete = $"DELETE FROM detalhes_pedido WHERE id_detalhe = '{IdDetalhe}';";

                objBD.ExecutarComando(delete);
                Limpar();
                MessageBox.Show($"Dados do registro {IdDetalhe} excluídos com sucesso.");
                ExibirDadosNoGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ExibirDadosNoGrid()
        {
            string consulta = "SELECT * FROM detalhes_pedido ORDER BY id_detalhe;";
            dtgDetalhes.DataSource = objBD.ExecutarConsulta(consulta);
        }

        private void Detalhes_Pedido_Load(object sender, EventArgs e)
        {
            ExibirDadosNoGrid();
        }

        private void dtgDetalhes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIdDetalhe.Text = dtgDetalhes.Rows[e.RowIndex].Cells["id_detalhe"].Value.ToString();
            txtIdPedido.Text = dtgDetalhes.Rows[e.RowIndex].Cells["id_pedido"].Value.ToString();
            txtIdQuadro.Text = dtgDetalhes.Rows[e.RowIndex].Cells["id_quadro"].Value.ToString();
            txtQuant.Text = dtgDetalhes.Rows[e.RowIndex].Cells["quantidade"].Value.ToString();
            txtPrecoUnit.Text = dtgDetalhes.Rows[e.RowIndex].Cells["preco_unitario"].Value.ToString();
        }
    }
}
