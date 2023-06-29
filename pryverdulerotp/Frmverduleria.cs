using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace pryverdulerotp
{
    public partial class Frmverduleria : Form
    {
        public Frmverduleria()
        {
            InitializeComponent();
        }
        public string Cone = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = VERDULEROS.mdb";
        private void btnGuardarproducto_Click(object sender, EventArgs e)
        {
            clsBaseDeDatos clsBaseDeDatos = new clsBaseDeDatos();
            clsBaseDeDatos.GrabarVen(Cone, "Ventas", Convert.ToInt32(cmbVendedor.SelectedValue), Convert.ToInt32(cmbProducto.SelectedValue), dtpFecha.Value, Convert.ToInt32(numKilos.Value));
            clsBaseDeDatos.CargarTab(Cone, "Ventas", dgvVentas);
        }

        private void Frmverduleria_Load(object sender, EventArgs e)
        {
            clsBaseDeDatos clsBaseDeDatos = new clsBaseDeDatos();
            clsBaseDeDatos.CargarTab(Cone, "Ventas", dgvVentas);
            clsBaseDeDatos.CargarPro(Cone, "Productos", cmbProducto);
            clsBaseDeDatos.CargarVen(Cone, "Vendedores", cmbVendedor);
        }
    }
}
