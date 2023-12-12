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
    public partial class Artistas : Form
    {
        public Artistas()
        {
            InitializeComponent();
        }

        Conexao objBD = new Conexao();

        private void Limpar()
        {
            txtID.Clear();
            txtEstilo.Clear();
            txtNacionalidade.Clear();
            txtNome.Clear();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                // armazenar em variáveis os valores digitados pelo usuário
                int ID = int.Parse(txtID.Text);
                string nome = txtNome.Text;
                string nacionalidade = txtNacionalidade.Text;
                string estilo = txtEstilo.Text;

                //criar instrução de insert 
                string inserir = $"INSERT INTO artistas VALUES('{ID}', '{nome}','{nacionalidade}','{estilo}');";

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

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                // armazenar em variáveis os valores digitados pelo usuário
                int ID = int.Parse(txtID.Text);
                string nome = txtNome.Text;
                string nacionalidade = txtNacionalidade.Text;
                string estilo = txtEstilo.Text;

                //criar instrução de update
                string update = $"UPDATE artistas SET id_artista = '{ID}', nome_artista = '{nome}', nacionalidade = '{nacionalidade}', estilo_artista = '{estilo}' WHERE id_artista = '{ID}';";

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
                string delete = $"DELETE FROM artistas WHERE id_artista = '{ID}';";

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
            string consulta = "SELECT * FROM artistas ORDER BY id_artista;";
            dtgArtistas.DataSource = objBD.ExecutarConsulta(consulta);
        }

        private void Artistas_Load(object sender, EventArgs e)
        {
            ExibirDadosNoGrid();
        }

        private void dtgArtistas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dtgArtistas.Rows[e.RowIndex].Cells["id_artista"].Value.ToString();
            txtNome.Text = dtgArtistas.Rows[e.RowIndex].Cells["nome_artista"].Value.ToString();
            txtNacionalidade.Text = dtgArtistas.Rows[e.RowIndex].Cells["nacionalidade"].Value.ToString();
            txtEstilo.Text = dtgArtistas.Rows[e.RowIndex].Cells["estilo_artista"].Value.ToString();
        }
    }
}
