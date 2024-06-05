using biblioteca1.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace biblioteca1
{
    public partial class Menu : Form
    {
        static clsTransacciones tran = new clsTransacciones();
        private String _sCon = clsConexion.cadenaConexion();
        public Menu()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }
    }
}
