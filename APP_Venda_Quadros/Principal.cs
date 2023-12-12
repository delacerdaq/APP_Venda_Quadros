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
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void artistasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Artistas obj = new Artistas();
            obj.ShowDialog();
        }

        private void quadrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quadros obj = new Quadros();
            obj.ShowDialog();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Clientes obj = new Clientes();
                obj.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void pedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pedidos obj = new Pedidos();
            obj.ShowDialog();
        }

        private void detalhesPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Detalhes_Pedido obj = new Detalhes_Pedido();
            obj.ShowDialog();
        }
    }
}
