using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Net.NetworkInformation;

namespace biblioteca1.Clases
{
    internal class clsTransacciones
    {
        #region VARIABLES
        Principal fac = new Principal();
        private String _idturno = "", _descripcion1 = "";
        private String _idgrupo = "", _descripcion2 = "";
        private String _idmateria = "", _descripcion = "";
        private String _idpersona = "",  _nombre = "", _paterno = "", _materno = "";
        private String _idevaluacion = "", _calificacion = "", _horas_cumplidas = "", _iddocenteE = "" , _idalumnoE= "";
        //docente
        private String _iddocente = "", _idpersonaD = "", _idmateriaD = "";
        //alumno
        private String _idalumno = "", _idpersonaA = "", _idgrupoA = "";

        private String _sCon = clsConexion.cadenaConexion(), _sSql = "";

        #endregion

        #region CONSTRUCTOR
        public clsTransacciones() { }
        #endregion

        #region GETTER AND SETTER

        #region VARIABLE MATERIA
        public String idmateria
        {
            get { return _idmateria; }
            set { _idmateria = value; }
        }
        public String descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
       


        #endregion
        //-----------------------
        #region VARIABLE PERSONA
        public String idpersona
        {
            get { return _idpersona; }
            set { _idpersona = value; }
        }
        public String nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public String paterno
        {
            get { return _paterno; }
            set { _paterno = value; }
        }

        public String materno
        {
            get { return _materno; }
            set { _materno = value; }
        }

        #endregion
        //-----------------------
        #region  VARIABLES TURNO
        public String idturno
        {
            get { return _idturno; }
            set { _idturno = value; }
        }
        public String descripcion1
        {
            get { return _descripcion1; }
            set { _descripcion1= value; }
        }
        #endregion
        //-----------------------
        #region  VARIABLES GRUPO
        public String idgrupo
        {
            get { return _idgrupo; }
            set { _idgrupo = value; }
        }
        public String descripcion2
        {
            get { return _descripcion2; }
            set { _descripcion2 = value; }
        }
        #endregion
        //----------------------
        #region  VARIABLES EVALUACION
        public String idevaluacion
        {
            get { return _idevaluacion; }
            set { _idevaluacion = value; }
        }
        public String calificacion
        {
            get { return _calificacion; }
            set { _calificacion = value; }
        }

        public String horascumplidas
        {
            get { return _horas_cumplidas; }
            set { _horas_cumplidas = value; }
        }

        public String iddocenteE
        {
            get { return _iddocenteE; }
            set { _iddocenteE = value; }
        }

        public String idalumnoE
        {
            get { return _idalumnoE; }
            set { _idalumnoE = value; }
        }
        #endregion
        //----------------------------
        #region  VARIABLES DOCENTE
        public String iddocente
        {
            get { return _iddocente; }
            set { _iddocente = value; }
        }
        public String idpersonaD
        {
            get { return _idpersonaD; }
            set { _idpersonaD = value; }
        }
        public String idmateriaD
        {
            get { return _idmateriaD; }
            set { _idmateriaD = value; }
        }

        #endregion
        //-------------------------------
        #region  VARIABLES ALUMNO
        public String idalumno
        {
            get { return _idalumno; }
            set { _idalumno = value; }
        }
        public String idpersonaA
        {
            get { return _idpersonaA; }
            set { _idpersonaA = value; }
        }

        public String idgrupoA
        {
            get { return _idgrupoA; }
            set { _idgrupoA = value; }
        }
        #endregion
        //----------------------------



        #endregion

        #region BUSQUEDA-INSERTAR-ELIMINAR-CARGAR PERSONA
        public DataTable cargaFactura()
        {
            DataTable tb = new DataTable();
            MySqlConnection conexion = new MySqlConnection(_sCon);
            try
            {
                //SELECT f.idfactura as FACTURA, f.status as ESTADO, f.fecha as FECHA, f.monto as MONTO, f.empresa as EMPRESA, p.nombre as NOMBRE
                //FROM facturas as f
                //INNER JOIN proveedores as p
                //ON f.idprovedor = p.idproveedor
                //WHERE f.idfactura = 1;

                //"SELECT f.idfactura as FACTURA, f.status as ESTADO, f.fecha as FECHA, f.monto as MONTO, f.empresa as EMPRESA, p.nombre as NOMBRE" +
                //    "FROM facturas as f" +
                //    "INNER JOIN proveedores as p" +
                //    "ON f.idprovedor = p.idproveedor" +
                //    "WHERE f.idfactura =" + _idfactura + ";"

                _sSql = "SELECT idpersona, nombre , paterno , materno FROM persona;";

               // _sSql = "SELECT idpersona as MATRICULA, nombre as Nombre, paterno as Paterno, materno as Materno FROM factura;";
                conexion.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(_sSql, _sCon);
                da.Fill(tb);
                conexion.Close();

                return (tb);

            }
            catch (MySqlException e)
            {
                MessageBox.Show("ERROR DE SISTEMA \n" + e);
                conexion.Close();

                return (tb);

            }
        }
        public Boolean insetarFactura()
        {
            MySqlConnection conexion = new MySqlConnection(_sCon);
            try
            {
                _sSql = "INSERT INTO persona (nombre,paterno,materno)VALUES (" +_nombre+", '"+_paterno+"', '"+_materno+"');";
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand(_sSql, conexion);
                cmd.ExecuteNonQuery();
                MessageBox.Show("REGISTRO GUARDADO CON EXITO :D", "REGISTRO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                cmd.Dispose();
                conexion.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex + "¡¡ATENCION!!");
                conexion.Close();
                return false;
            }
        }
        public Boolean eliminarFactura()
        {
            MySqlConnection conexion = new MySqlConnection(_sCon);
            try
            {
                _sSql = "DELETE FROM persona WHERE idpersona = " + _idpersona + ";";
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand(_sSql, conexion);
                cmd.ExecuteNonQuery();
                MessageBox.Show("REGISTRO ELIMINADO CON EXITO :O", "ELIMINAR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmd.Dispose();
                conexion.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("¡¡ERROR DE SISTEMA!!\n" + ex);
                conexion.Close();
                return false;
            }

        }
        public DataTable buscarFactura()
        {
            DataTable tb = new DataTable();
            MySqlConnection conexion = new MySqlConnection(_sCon);
            try
            {
                _sSql = "SELECT p.idpersona as Matricula, p.nombre as Nombre, p.paterno as Paterno, p.materno as Materno FROM persona as p WHERE p.idpersona = " + _idpersona + ";";

                conexion.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(_sSql, _sCon);
                da.Fill(tb);
                conexion.Close();

                return (tb);
            }
            catch (MySqlException e)
            {
                MessageBox.Show("ERROR DE SISTEMA \n" + e);
                conexion.Close();

                return (tb);

            }
        }
        public Boolean modificarFactura()
        {
            MySqlConnection conexion = new MySqlConnection(_sCon);
            try
            {
                _sSql = "UPDATE persona SET nombre=" + _nombre + ",paterno=" + _paterno + ",materno=" + _materno + " WHERE idpersona=" + _idpersona + ";";
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand(_sSql, conexion);
                cmd.ExecuteNonQuery();
                MessageBox.Show("EL REGISTRO SE MODIFICO CON EXITO :D", "MODIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conexion.Close();
                conexion.Dispose();


                return true;
            }
            catch (MySqlException e)
            {
                MessageBox.Show("ERROR DE SISTEMA\n" + e, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

        }
        #endregionz

        #region BUSQUEDA-INSERTAR-ELIMINAR-CARGAR MATERIA
        public DataTable cargaTABLAM()
        {
            DataTable tb = new DataTable();
            MySqlConnection conexion = new MySqlConnection(_sCon);
            try
            {
                //SELECT f.idfactura as FACTURA, f.status as ESTADO, f.fecha as FECHA, f.monto as MONTO, f.empresa as EMPRESA, p.nombre as NOMBRE
                //FROM facturas as f
                //INNER JOIN proveedores as p
                //ON f.idprovedor = p.idproveedor
                //WHERE f.idfactura = 1;

                //"SELECT f.idfactura as FACTURA, f.status as ESTADO, f.fecha as FECHA, f.monto as MONTO, f.empresa as EMPRESA, p.nombre as NOMBRE" +
                //    "FROM facturas as f" +
                //    "INNER JOIN proveedores as p" +
                //    "ON f.idprovedor = p.idproveedor" +
                //    "WHERE f.idfactura =" + _idfactura + ";"

                _sSql = "SELECT idmateria , descripcion FROM Materia;";

                // _sSql = "SELECT idpersona as MATRICULA, nombre as Nombre, paterno as Paterno, materno as Materno FROM factura;";
                conexion.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(_sSql, _sCon);
                da.Fill(tb);
                conexion.Close();

                return (tb);

            }
            catch (MySqlException e)
            {
                MessageBox.Show("ERROR DE SISTEMA \n" + e);
                conexion.Close();

                return (tb);

            }
        }
        public Boolean insertarmateria()
        {
            MySqlConnection conexion = new MySqlConnection(_sCon);
            try
            {
                _sSql = "INSERT INTO materia VALUES (" + _idmateria + "," + _descripcion + "');";
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand(_sSql, conexion);
                cmd.ExecuteNonQuery();
                MessageBox.Show("REGISTRO GUARDADO CON EXITO :D", "REGISTRO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                cmd.Dispose();
                conexion.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex + "¡¡ATENCION!!");
                conexion.Close();
                return false;
            }
        }
        public Boolean eliminarmateria()
        {
            MySqlConnection conexion = new MySqlConnection(_sCon);
            try
            {
                _sSql = "DELETE FROM materia WHERE idmateria = " + _idmateria + ";";
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand(_sSql, conexion);
                cmd.ExecuteNonQuery();
                MessageBox.Show("REGISTRO ELIMINADO CON EXITO :O", "ELIMINAR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmd.Dispose();
                conexion.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("¡¡ERROR DE SISTEMA!!\n" + ex);
                conexion.Close();
                return false;
            }

        }
        public DataTable buscarmateria()
        {
            DataTable tb = new DataTable();
            MySqlConnection conexion = new MySqlConnection(_sCon);
            try
            {
                _sSql = "SELECT idmateria, descripcion FROM materia WHERE idmateria = " + _idmateria + ";";

                conexion.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(_sSql, _sCon);
                da.Fill(tb);
                conexion.Close();

                return (tb);
            }
            catch (MySqlException e)
            {
                MessageBox.Show("ERROR DE SISTEMA \n" + e);
                conexion.Close();

                return (tb);

            }
        }
        public Boolean modificarmateria()
        {
            MySqlConnection conexion = new MySqlConnection(_sCon);
            try
            {
                _sSql = "UPDATE materia SET descripcion=" + _descripcion +  " WHERE idmateria=" + _idmateria + ";";
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand(_sSql, conexion);
                cmd.ExecuteNonQuery();
                MessageBox.Show("EL REGISTRO SE MODIFICO CON EXITO :D", "MODIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conexion.Close();
                conexion.Dispose();


                return true;
            }
            catch (MySqlException e)
            {
                MessageBox.Show("ERROR DE SISTEMA\n" + e, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

        }
        #endregion

        #region BUSQUEDA-INSERTAR-ELIMINAR-CARGAR TURNO
        public DataTable cargarturno()
        {
            DataTable tb = new DataTable();
            MySqlConnection conexion = new MySqlConnection(_sCon);
            try
            {
                //SELECT f.idfactura as FACTURA, f.status as ESTADO, f.fecha as FECHA, f.monto as MONTO, f.empresa as EMPRESA, p.nombre as NOMBRE
                //FROM facturas as f
                //INNER JOIN proveedores as p
                //ON f.idprovedor = p.idproveedor
                //WHERE f.idfactura = 1;

                //"SELECT f.idfactura as FACTURA, f.status as ESTADO, f.fecha as FECHA, f.monto as MONTO, f.empresa as EMPRESA, p.nombre as NOMBRE" +
                //    "FROM facturas as f" +
                //    "INNER JOIN proveedores as p" +
                //    "ON f.idprovedor = p.idproveedor" +
                //    "WHERE f.idfactura =" + _idfactura + ";"

                _sSql = "SELECT idturno , descripcion FROM turno;";

                // _sSql = "SELECT idpersona as MATRICULA, nombre as Nombre, paterno as Paterno, materno as Materno FROM factura;";
                conexion.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(_sSql, _sCon);
                da.Fill(tb);
                conexion.Close();

                return (tb);

            }
            catch (MySqlException e)
            {
                MessageBox.Show("ERROR DE SISTEMA \n" + e);
                conexion.Close();

                return (tb);

            }
        }
        public Boolean insertarturno()
        {
            MySqlConnection conexion = new MySqlConnection(_sCon);
            try
            {
                _sSql = "INSERT INTO turno VALUES (" + _idturno + "," + _descripcion1 + "');";
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand(_sSql, conexion);
                cmd.ExecuteNonQuery();
                MessageBox.Show("REGISTRO GUARDADO CON EXITO :D", "REGISTRO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                cmd.Dispose();
                conexion.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex + "¡¡ATENCION!!");
                conexion.Close();
                return false;
            }
        }
        public Boolean eliminarturno()
        {
            MySqlConnection conexion = new MySqlConnection(_sCon);
            try
            {
                _sSql = "DELETE FROM turno WHERE idturno = " + _idturno + ";";
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand(_sSql, conexion);
                cmd.ExecuteNonQuery();
                MessageBox.Show("REGISTRO ELIMINADO CON EXITO :O", "ELIMINAR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmd.Dispose();
                conexion.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("¡¡ERROR DE SISTEMA!!\n" + ex);
                conexion.Close();
                return false;
            }

        }
        public DataTable buscarturno()
        {
            DataTable tb = new DataTable();
            MySqlConnection conexion = new MySqlConnection(_sCon);
            try
            {
                _sSql = "SELECT idturno, descripcion FROM turno WHERE idturno = " + _idturno + ";";

                conexion.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(_sSql, _sCon);
                da.Fill(tb);
                conexion.Close();

                return (tb);
            }
            catch (MySqlException e)
            {
                MessageBox.Show("ERROR DE SISTEMA \n" + e);
                conexion.Close();

                return (tb);

            }
        }
        public Boolean modificarturno()
        {
            MySqlConnection conexion = new MySqlConnection(_sCon);
            try
            {
                _sSql = "UPDATE turno SET descripcion=" + _descripcion + " WHERE idturno=" + _idturno + ";";
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand(_sSql, conexion);
                cmd.ExecuteNonQuery();
                MessageBox.Show("EL REGISTRO SE MODIFICO CON EXITO :D", "MODIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conexion.Close();
                conexion.Dispose();


                return true;
            }
            catch (MySqlException e)
            {
                MessageBox.Show("ERROR DE SISTEMA\n" + e, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

        }
        #endregion

        #region BUSQUEDA-INSERTAR-ELIMINAR-CARGAR GRUPO
        public DataTable cargargrupo()
        {
            DataTable tb = new DataTable();
            MySqlConnection conexion = new MySqlConnection(_sCon);
            try
            {
                //SELECT f.idfactura as FACTURA, f.status as ESTADO, f.fecha as FECHA, f.monto as MONTO, f.empresa as EMPRESA, p.nombre as NOMBRE
                //FROM facturas as f
                //INNER JOIN proveedores as p
                //ON f.idprovedor = p.idproveedor
                //WHERE f.idfactura = 1;

                //"SELECT f.idfactura as FACTURA, f.status as ESTADO, f.fecha as FECHA, f.monto as MONTO, f.empresa as EMPRESA, p.nombre as NOMBRE" +
                //    "FROM facturas as f" +
                //    "INNER JOIN proveedores as p" +
                //    "ON f.idprovedor = p.idproveedor" +
                //    "WHERE f.idfactura =" + _idfactura + ";"

                _sSql = "SELECT idgrupo , descripcion FROM grupo;";

                // _sSql = "SELECT idpersona as MATRICULA, nombre as Nombre, paterno as Paterno, materno as Materno FROM factura;";
                conexion.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(_sSql, _sCon);
                da.Fill(tb);
                conexion.Close();

                return (tb);

            }
            catch (MySqlException e)
            {
                MessageBox.Show("ERROR DE SISTEMA \n" + e);
                conexion.Close();

                return (tb);

            }
        }
        public Boolean insertargrupo()
        {
            MySqlConnection conexion = new MySqlConnection(_sCon);
            try
            {
                _sSql = "INSERT INTO grupo VALUES (" + _idgrupo + "," + _descripcion2 + "');";
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand(_sSql, conexion);
                cmd.ExecuteNonQuery();
                MessageBox.Show("REGISTRO GUARDADO CON EXITO :D", "REGISTRO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                cmd.Dispose();
                conexion.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex + "¡¡ATENCION!!");
                conexion.Close();
                return false;
            }
        }
        public Boolean eliminargrupo()
        {
            MySqlConnection conexion = new MySqlConnection(_sCon);
            try
            {
                _sSql = "DELETE FROM grupo WHERE idgrupo = " + _idgrupo + ";";
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand(_sSql, conexion);
                cmd.ExecuteNonQuery();
                MessageBox.Show("REGISTRO ELIMINADO CON EXITO :O", "ELIMINAR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmd.Dispose();
                conexion.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("¡¡ERROR DE SISTEMA!!\n" + ex);
                conexion.Close();
                return false;
            }

        }
        public DataTable buscargrupo()
        {
            DataTable tb = new DataTable();
            MySqlConnection conexion = new MySqlConnection(_sCon);
            try
            {
                _sSql = "SELECT idgrupo, descripcion FROM grupo WHERE idgrupo = " + _idgrupo + ";";

                conexion.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(_sSql, _sCon);
                da.Fill(tb);
                conexion.Close();

                return (tb);
            }
            catch (MySqlException e)
            {
                MessageBox.Show("ERROR DE SISTEMA \n" + e);
                conexion.Close();

                return (tb);

            }
        }
        public Boolean modificargrupo()
        {
            MySqlConnection conexion = new MySqlConnection(_sCon);
            try
            {
                _sSql = "UPDATE grupo SET descripcion=" + _descripcion2 + " WHERE idgrupo=" + _idgrupo + ";";
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand(_sSql, conexion);
                cmd.ExecuteNonQuery();
                MessageBox.Show("EL REGISTRO SE MODIFICO CON EXITO :D", "MODIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conexion.Close();
                conexion.Dispose();


                return true;
            }
            catch (MySqlException e)
            {
                MessageBox.Show("ERROR DE SISTEMA\n" + e, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

        }
        #endregion

        #region BUSQUEDA-INSERTAR-ELIMINAR-CARGAR EVALUACION
        public DataTable cargarevaluacion()
        {
            DataTable tb = new DataTable();
            MySqlConnection conexion = new MySqlConnection(_sCon);
            try
            {
                //SELECT f.idfactura as FACTURA, f.status as ESTADO, f.fecha as FECHA, f.monto as MONTO, f.empresa as EMPRESA, p.nombre as NOMBRE
                //FROM facturas as f
                //INNER JOIN proveedores as p
                //ON f.idprovedor = p.idproveedor
                //WHERE f.idfactura = 1;

                //"SELECT f.idfactura as FACTURA, f.status as ESTADO, f.fecha as FECHA, f.monto as MONTO, f.empresa as EMPRESA, p.nombre as NOMBRE" +
                //    "FROM facturas as f" +
                //    "INNER JOIN proveedores as p" +
                //    "ON f.idprovedor = p.idproveedor" +
                //    "WHERE f.idfactura =" + _idfactura + ";"

                _sSql = "SELECT idevaluacion , calificacion, horas_cumplidas, iddocente, idalumno FROM evaluacion;";

                // _sSql = "SELECT idpersona as MATRICULA, nombre as Nombre, paterno as Paterno, materno as Materno FROM factura;";
                conexion.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(_sSql, _sCon);
                da.Fill(tb);
                conexion.Close();

                return (tb);

            }
            catch (MySqlException e)
            {
                MessageBox.Show("ERROR DE SISTEMA \n" + e);
                conexion.Close();

                return (tb);

            }
        }
        public Boolean insertarevaluacion()
        {
            MySqlConnection conexion = new MySqlConnection(_sCon);
            try
            {
                _sSql = "INSERT INTO evaluacion VALUES (" + _idevaluacion + "," + _calificacion + ", '" + _horas_cumplidas + "', '" + _iddocenteE + "', '" + _idalumnoE + "');";
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand(_sSql, conexion);
                cmd.ExecuteNonQuery();
                MessageBox.Show("REGISTRO GUARDADO CON EXITO :D", "REGISTRO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                cmd.Dispose();
                conexion.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex + "¡¡ATENCION!!");
                conexion.Close();
                return false;
            }
        }
        public Boolean eliminarevaluacion()
        {
            MySqlConnection conexion = new MySqlConnection(_sCon);
            try
            {
                _sSql = "DELETE FROM evaluacion WHERE idevaluacion = " + _idevaluacion + ";";
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand(_sSql, conexion);
                cmd.ExecuteNonQuery();
                MessageBox.Show("REGISTRO ELIMINADO CON EXITO :O", "ELIMINAR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmd.Dispose();
                conexion.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("¡¡ERROR DE SISTEMA!!\n" + ex);
                conexion.Close();
                return false;
            }

        }
        public DataTable buscarevaluacion()
        {
            DataTable tb = new DataTable();
            MySqlConnection conexion = new MySqlConnection(_sCon);
            try
            {
                _sSql = "SELECT idevaluacion , calificacion, horas_cumplidas, iddocente, idalumno FROM evaluacion WHERE idevaluacion = " + _idevaluacion + ";";

                conexion.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(_sSql, _sCon);
                da.Fill(tb);
                conexion.Close();

                return (tb);
            }
            catch (MySqlException e)
            {
                MessageBox.Show("ERROR DE SISTEMA \n" + e);
                conexion.Close();

                return (tb);

            }
        }
        public Boolean modificarevaluacion()
        {
            MySqlConnection conexion = new MySqlConnection(_sCon);
            try
            {
                _sSql = "UPDATE evaluacion SET calificacion=" + _calificacion + ",horas_cumplidas=" + _horas_cumplidas + ",iddocente=" + _iddocenteE + ",idalumno=" + _idalumnoE + ";";
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand(_sSql, conexion);
                cmd.ExecuteNonQuery();
                MessageBox.Show("EL REGISTRO SE MODIFICO CON EXITO :D", "MODIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conexion.Close();
                conexion.Dispose();


                return true;
            }
            catch (MySqlException e)
            {
                MessageBox.Show("ERROR DE SISTEMA\n" + e, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

        }
        #endregion

    }
}
