using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Data.Common;

namespace pryverdulerotp
{
    internal class clsBaseDeDatos
    {
        public OleDbCommand Coman = new OleDbCommand();
        public OleDbDataReader Lec;
        public OleDbConnection Cone = new OleDbConnection();

        public void CargarTab(string cadenaConexion, string tabla, DataGridView dgvTablas)
        {
            try
            {
                Cone.ConnectionString = cadenaConexion;

                Coman.Connection = Cone;
                Coman.CommandText = tabla;
                Coman.CommandType = CommandType.TableDirect;
                Coman.Connection.Open();

                Lec = Coman.ExecuteReader();

                DataTable DataTable = new DataTable();
                DataTable.Load(Lec);

                dgvTablas.DataSource = DataTable;

                Coman.Connection.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        public void CargarVen(string cadenaConexion, string tabla, ComboBox cmbVendedores)
        {
            try
            {
                Cone.ConnectionString = cadenaConexion;

                Coman.Connection = Cone;
                Coman.CommandText = tabla;
                Coman.CommandType = CommandType.TableDirect;
                Coman.Connection.Open();

                Lec = Coman.ExecuteReader();

                if (Lec.HasRows)
                {
                    DataTable DataTable = new DataTable();
                    DataTable.Load(Lec);

                    cmbVendedores.DataSource = DataTable;
                    cmbVendedores.ValueMember = "IdVendedor";
                    cmbVendedores.DisplayMember = "NombreVendedor";
                }

                Coman.Connection.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        public void CargarPro(string cadenaConexion, string tabla, ComboBox cmbProductos)
        {
            try
            {
                Cone.ConnectionString = cadenaConexion;

                Coman.Connection = Cone;
                Coman.CommandText = tabla;
                Coman.CommandType = CommandType.TableDirect;
                Coman.Connection.Open();

                Lec = Coman.ExecuteReader();

                if (Lec.HasRows)
                {
                    DataTable DataTable = new DataTable();
                    DataTable.Load(Lec);

                    cmbProductos.DataSource = DataTable;
                    cmbProductos.ValueMember = "IdProducto";
                    cmbProductos.DisplayMember = "NomProducto";
                }

                Coman.Connection.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message + "haga la Cargar de los Productos");
            }
        }

        public void GrabarVen(string cadenaConexion, string tabla, int idVendedor, int idProducto, DateTime fecha, int kilos)
        {
            try
            {
                Cone.ConnectionString = cadenaConexion;
                string query = "INSERT INTO Ventas (`Cod Vendedor`,`Cod Producto`,Fecha,Kilos) VALUES (?,?,?,?)";

                using (Coman = new OleDbCommand(query, Cone))
                {
                    Coman.Parameters.AddWithValue("Cod Vendedor", idVendedor);
                    Coman.Parameters.AddWithValue("Cod Producto", idProducto);
                    Coman.Parameters.AddWithValue("Fecha", fecha.Date);
                    Coman.Parameters.AddWithValue("Kilos", kilos);

                    Coman.Connection.Open();

                    Coman.ExecuteNonQuery();

                    Coman.Connection.Close();
                }

                MessageBox.Show("la Venta fue ingresada correctamente!", "la Venta fue ingresada exitosamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message + error.Data + error.Source);
            }
        }
    }
}
