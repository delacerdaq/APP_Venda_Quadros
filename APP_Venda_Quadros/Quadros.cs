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
    public partial class Quadros : Form
    {
        public Quadros()
        {
            InitializeComponent();
        }

        Conexao objBD = new Conexao();

        private void Limpar()
        {
            txtAno.Clear();
            txtIdArtista.Clear();
            txtIdQuadro.Clear();
            txtPreco.Clear();
            txtTitle.Clear();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                // armazenar em variáveis os valores digitados pelo usuário
                int ano = int.Parse(txtAno.Text);
                int IdArtista = int.Parse(txtIdArtista.Text);
                int IdQuadro = int.Parse(txtIdQuadro.Text);
                double preco = double.Parse(txtPreco.Text);
                string titulo = txtTitle.Text;

                //criar instrução de insert 
                string inserir = $"INSERT INTO quadros VALUES('{IdQuadro}', '{IdArtista}','{titulo}','{ano}','{preco}');";

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
                int ano = int.Parse(txtAno.Text);
                int IdArtista = int.Parse(txtIdArtista.Text);
                int IdQuadro = int.Parse(txtIdQuadro.Text);
                double preco = double.Parse(txtPreco.Text);
                string titulo = txtTitle.Text;

                //criar instrução de update
                string update = $"UPDATE quadros SET id_quadro = '{IdQuadro}', id_artista = '{IdArtista}', titulo_quadro = '{titulo}', ano_criacao = '{ano}', preco = '{preco.ToString().Replace(".", ",")}' WHERE id_quadro = '{IdQuadro}';";

                objBD.ExecutarComando(update);
                Limpar();
                MessageBox.Show($"Dados do registro {IdQuadro} alterados com sucesso.");
                ExibirDadosNoGrid();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                // armazenar em variáveis os valores digitados pelo usuário
                int IdQuadro = int.Parse(txtIdQuadro.Text);

                //criar instrução de insert 
                string delete = $"DELETE FROM quadros WHERE id_quadro = '{IdQuadro}';";

                objBD.ExecutarComando(delete);
                Limpar();
                MessageBox.Show($"Dados do registro {IdQuadro} excluídos com sucesso.");
                ExibirDadosNoGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ExibirDadosNoGrid()
        {
            string consulta = "SELECT quadros.id_quadro, quadros.id_artista, quadros.titulo_quadro, quadros.ano_criacao, quadros.preco, artistas.nome_artista FROM quadros inner join artistas on quadros.id_artista = artistas.id_artista;";
            dtgQuadros.DataSource = objBD.ExecutarConsulta(consulta);
        }

        private void dtgQuadros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIdQuadro.Text = dtgQuadros.Rows[e.RowIndex].Cells["id_quadro"].Value.ToString();
            txtIdArtista.Text = dtgQuadros.Rows[e.RowIndex].Cells["id_artista"].Value.ToString();
            txtTitle.Text = dtgQuadros.Rows[e.RowIndex].Cells["titulo_quadro"].Value.ToString();
            txtAno.Text = dtgQuadros.Rows[e.RowIndex].Cells["ano_criacao"].Value.ToString();
            txtPreco.Text = dtgQuadros.Rows[e.RowIndex].Cells["preco"].Value.ToString();
        }

        private void Quadros_Load(object sender, EventArgs e)
        {
            ExibirDadosNoGrid();
        }
    }
}
