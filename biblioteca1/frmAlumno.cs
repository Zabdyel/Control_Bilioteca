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
using biblioteca1.Clases;



using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq.Expressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace biblioteca1
{
    public partial class Principal : Form

    {

        static clsTransacciones tran = new clsTransacciones();
        private String _sCon = clsConexion.cadenaConexion();

        public Principal()
        {
            InitializeComponent();
        }

        private void btnregistrarA_Click(object sender, EventArgs e)
        {

            if ( txtnombreA.Text.Equals("") || txtapellidoPA.Text.Equals("") || txtapellidomaternoA.Text.Equals(""))
            {
                MessageBox.Show("DEBE DE LLENAR TODOS LOS CAMPOS PARA EL REGISTRO", "REGISTRAR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
              
                tran.nombre = txtnombreA.Text;
                tran.paterno = txtapellidoPA.Text;
                tran.materno = txtapellidomaternoA.Text;
               
                tran.insetarFactura();

                LimpiarCasilla();
                tbldatos1.DataSource = tran.cargaFactura();
            }
        }

        #region LIMPIAR CASILLA
        private void LimpiarCasilla()
        {
            //persona
                     
            txtnombreA.Clear();
            txtapellidoPA.Clear();
            txtapellidomaternoA.Clear();

            //materias
            txtidmateria.Clear();
            txtdescripcionMateria.Clear();

            //turno
            txtidturno.Clear();
            txbdescripcionTurno.Clear();
        }
        #endregion

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            if (tbxmatriculaA.Text.Equals(""))
            {
                MessageBox.Show("SELECCIONE EL ID DE LA FACTURA", "BUSCAR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                tran.idpersona = tbxmatriculaA.Text;
                tbldatos1.DataSource = tran.buscarFactura();
                LimpiarCasilla();
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {

            try
            {
                DialogResult respuesta = MessageBox.Show("¿ESTAS SEGURO DE ELIMINAR ESTE REGISTRO?", "ELIMINAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    tran.idpersona = tbldatos1.SelectedCells[0].Value.ToString();
                    tran.eliminarFactura();
                    tbldatos1.DataSource = tran.cargaFactura();

                }
            }
            catch (Exception w)
            {
                MessageBox.Show("" + w);

            }
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            tbldatos1.DataSource = tran.cargaFactura();
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            if (tbxmatriculaA.Text.Equals("") || txtnombreA.Text.Equals("") || txtapellidoPA.Text.Equals("") || txtapellidomaternoA.Text.Equals(""))
            {
                MessageBox.Show("DEBE DE LLENAR TODOS LOS CAMPOS PARA EL REGISTRO", "REGISTRAR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                tran.idpersona = tbxmatriculaA.Text;
                tran.nombre = txtnombreA.Text;
                tran.paterno = txtapellidoPA.Text;
                tran.materno = txtapellidomaternoA.Text;

                tran.insetarFactura();

                LimpiarCasilla();
                tbldatos1.DataSource = tran.cargaFactura();
            }
        }
        //materias
        private void btnregistrarM_Click(object sender, EventArgs e)
        {
            if (txtidmateria.Text.Equals("") || txtdescripcionMateria.Text.Equals(""))
            {
                MessageBox.Show("DEBE DE LLENAR TODOS LOS CAMPOS PARA EL REGISTRO", "REGISTRAR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                tran.idpersona = txtidmateria.Text;
                tran.descripcion = txtdescripcionMateria.Text;
                

                tran.insertarmateria();

                LimpiarCasilla();
                tbldatosM.DataSource = tran.cargaTABLAM();
            }
        }

        private void btnbuscarM_Click(object sender, EventArgs e)
        {
            if (txtidmateria.Text.Equals(""))
            {
                MessageBox.Show("SELECCIONE EL ID DE LA FACTURA", "BUSCAR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                tran.idmateria = txtidmateria.Text;
                tbldatosM.DataSource = tran.buscarmateria();
                LimpiarCasilla();
            }
        }

        private void btneliminarM_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult respuesta = MessageBox.Show("¿ESTAS SEGURO DE ELIMINAR ESTE REGISTRO?", "ELIMINAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    tran.idmateria = tbldatosM.SelectedCells[0].Value.ToString();
                    tran.eliminarmateria();
                    tbldatos1.DataSource = tran.cargaFactura();

                }
            }
            catch (Exception w)
            {
                MessageBox.Show("" + w);

            }
        }

        private void btnactualizar_Click(object sender, EventArgs e)
        {
            tbldatosM.DataSource = tran.cargaTABLAM();
        }

        //turno
        private void btnregistrarturno_Click(object sender, EventArgs e)
        {
            if (txtidturno.Text.Equals("") || txbdescripcionTurno.Text.Equals(""))
            {
                MessageBox.Show("DEBE DE LLENAR TODOS LOS CAMPOS PARA EL REGISTRO", "REGISTRAR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                tran.idturno= txtidturno.Text;
                tran.descripcion1 = txbdescripcionTurno.Text;


                tran.insertarturno();

                LimpiarCasilla();
                tbldatosturno.DataSource = tran.cargarturno();
            }
        }

        private void btnbuscarturno_Click(object sender, EventArgs e)
        {
            if (txtidturno.Text.Equals(""))
            {
                MessageBox.Show("SELECCIONE EL ID DE LA FACTURA", "BUSCAR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                tran.idturno = txtidturno.Text;
                tbldatosturno.DataSource = tran.buscarturno();
                LimpiarCasilla();
            }
        }

        private void btneliminarturno_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult respuesta = MessageBox.Show("¿ESTAS SEGURO DE ELIMINAR ESTE REGISTRO?", "ELIMINAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    tran.idturno = tbldatosturno.SelectedCells[0].Value.ToString();
                    tran.eliminarturno();
                    tbldatosturno.DataSource = tran.cargarturno();

                }
            }
            catch (Exception w)
            {
                MessageBox.Show("" + w);

            }
        }

        private void btnmodificarturno_Click(object sender, EventArgs e)
        {

        }

        private void btnactualizarturno_Click(object sender, EventArgs e)
        {
            tbldatosturno.DataSource = tran.cargarturno();
        }

        //grupo
        private void button20_Click(object sender, EventArgs e)
        {
            if (txtidgrupo.Text.Equals("") || txtdescripciongrupo.Text.Equals(""))
            {
                MessageBox.Show("DEBE DE LLENAR TODOS LOS CAMPOS PARA EL REGISTRO", "REGISTRAR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                tran.idgrupo = txtidgrupo.Text;
                tran.descripcion2 = txtdescripciongrupo.Text;


                tran.insertargrupo();

                LimpiarCasilla();
                tbldatosgrupos.DataSource = tran.cargargrupo();
            }
        }

        private void buscargrupo_Click(object sender, EventArgs e)
        {
            if (txtidgrupo.Text.Equals(""))
            {
                MessageBox.Show("SELECCIONE EL ID DE LA FACTURA", "BUSCAR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                tran.idgrupo = txtidgrupo.Text;
                tbldatosgrupos.DataSource = tran.buscargrupo();
                LimpiarCasilla();
            }
        }

        private void modificargrupo_Click(object sender, EventArgs e)
        {

        }

        private void eliminargrupo_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult respuesta = MessageBox.Show("¿ESTAS SEGURO DE ELIMINAR ESTE REGISTRO?", "ELIMINAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    tran.idgrupo = tbldatosgrupos.SelectedCells[0].Value.ToString();
                    tran.eliminarturno();
                    tbldatosgrupos.DataSource = tran.cargargrupo();

                }
            }
            catch (Exception w)
            {
                MessageBox.Show("" + w);

            }
        }

        private void actualizargrupo_Click(object sender, EventArgs e)
        {
            tbldatosgrupos.DataSource = tran.cargargrupo();
        }
    }
}
