using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace borrador
{
    public partial class Form2 : Form
    {
        public static List<Productos> productos = new List<Productos>();

        public int n = 0;
        public class Productos
        {
            public string _codigo { get; set; }
            public string _nombre { get; set; }
            public double _precio { get; set; }

            public Productos(string codigo, string nombre, double precio)
            {
                _codigo = codigo;
                _nombre = nombre;
                _precio = precio;
            }
        }

        public Form2()
        {
            InitializeComponent();
            lblform.Text = " ";
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {

            try
            {

                string codigo = (productos.Count() + 1).ToString().PadLeft(5, '0');
                string nombre = txtNombre.Text;
                double precio = Convert.ToDouble(txtPrecio.Text);


                if (precio == 0)
                {
                    throw new Exception("El precio no puede ser 0");
                }
                else if (precio < 0)
                {
                    throw new Exception("El precio no puede ser negativo");
                }

                if (txtPrecio.Text == null)
                {
                    throw new Exception("el precio no puede ser vacio");
                }


                if (string.IsNullOrEmpty(nombre))
                {
                    throw new Exception("El nombre del producto no puede ser vacio!");
                }


                int n = dtgvProductos.Rows.Add();
                Productos prod = new Productos(codigo, nombre, precio);
                productos.Add(prod);
                dtgvProductos.Rows[n].Cells[0].Value = codigo;
                dtgvProductos.Rows[n].Cells[1].Value = nombre;
                dtgvProductos.Rows[n].Cells[2].Value = precio + "$";

                txtCodigo.Clear();
                txtPrecio.Clear();
                txtNombre.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }



        private void dtgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            n = e.RowIndex;

            if (n != -1)
            {

                lblform.Text = " ";
            }
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if (n != -1 && dtgvProductos.Rows.Count > 0)
                {
                    dtgvProductos.Rows.RemoveAt(n);
                }
                else
                {
                    throw new Exception("No se pueden eliminar más artículos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

    }
}

//{
//        private int n = 0;
//        public Form2()
//        {
//            InitializeComponent();
//            lblform.Text = " ";
//        }

//        private void btnAgregarProducto_Click(object sender, EventArgs e)
//        {
//            int n = dtgvProductos.Rows.Add();
           
//            dtgvProductos.Rows[n].Cells[0].Value = txtCodigo.Text;
//            dtgvProductos.Rows[n].Cells[1].Value = txtNombre.Text;
//            dtgvProductos.Rows[n].Cells[2].Value = txtPrecio.Text + "$";

//            txtCodigo.Text = " ";
//            txtPrecio.Text = " ";
//            txtNombre.Text = " ";

//    }

        

//        private void dtgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
//        {
//            n = e.RowIndex;

//            if(n != -1 ) {

//                lblform.Text = " ";
//            }
//        }

//        private void btnEliminarProducto_Click(object sender, EventArgs e)
//        {

//            if (n != -1)
//            {
//                dtgvProductos.Rows.RemoveAt(n);
//            }

//        }

//        private void btnImportar_Click(object sender, EventArgs e)
//        {

//        }

//        private void button1_Click(object sender, EventArgs e)
//        {

//        }
//    }
//}
