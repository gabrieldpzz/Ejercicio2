using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        /*listado que permite tener varios elementos de la clase Persona*/
        private List<Producto> Productos = new List<Producto>();
        private int edit_indice = -1; //el índice para editar comienza en -1, esto significa que 
        //no hay ninguno seleccionado, esto servirá para el DataGridView
        class Producto
        {
            string nombre;
            public string Nombre
            {
                get { return nombre; }
                set { nombre = value; }
            }
            string descripcion;
            public string Descripcion
            {
                get { return descripcion; }
                set { descripcion = value; }
            }
            string marca;
            public string Marca
            {
                get { return marca; }
                set { marca = value; }
            }
            float precio;
            public float Precio
            {
                get { return precio; }
                set { precio = value; }
            }
            int stock;
            public int Stock
            {
                get { return stock; }
                set { stock = value; }
            }
            string rutaImagen;
            public string RutaImagen
            {
                get { return rutaImagen; }
                set { rutaImagen = value; }
            }
        }

        private void actualizarGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Productos; /*los nombres de columna que veremos son 
              los de las propiedades*/
        }
        private void reseteo()
        {
            txtnombre.Clear();
            txtdescripcion.Clear();
            txtmarca.Clear();
            txtprecio.Clear();
            txtstock.Clear();
            txtruta.Clear();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //object foto = @"C:\Users\tirze\Downloads\desktop-wallpaper-minecraft-dirt-texture.jpg";
            //dataGridView1.Rows.Add(foto);}

            // Crea un nuevo temporizador
            timer1 = new System.Windows.Forms.Timer();

            // Establece el intervalo del temporizador en 1 segundo
            timer1.Interval = 1000;

            // Agrega el evento Tick al temporizador
            timer1.Tick += new EventHandler(timer1_Tick);

            // Inicia el temporizador
            timer1.Start();


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Obtiene la ruta de la imagen del cuadro de texto
            string rutaImagen = txtruta.Text;

            // Si la ruta de la imagen no está vacía
            if (!string.IsNullOrEmpty(rutaImagen))
            {
                // Carga la imagen desde el archivo
                Image imagen = Image.FromFile(rutaImagen);

                // Muestra la imagen en el PictureBox
                pictureBox3.Image = imagen;
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {


            DataGridViewRow selected = dataGridView1.SelectedRows[0];
            int posicion = dataGridView1.Rows.IndexOf(selected); //almacena en cual fila estoy
            edit_indice = posicion; //copio esa variable en índice editado
            Producto product = Productos[posicion]; /*esta variable de tipo persona, se carga 
                con los valores que le pasa el listado*/
            //lo que tiene el atributo se lo doy al textbox
            txtnombre.Text = product.Nombre;
            txtdescripcion.Text = product.Descripcion;
            txtmarca.Text = product.Marca;
            txtprecio.Text = Convert.ToString(product.Precio);
            txtstock.Text = Convert.ToString(product.Stock);
            txtruta.Text = product.RutaImagen;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            //creo un objeto de la clase persona y guardo a través de las propiedades
            Producto product = new Producto();
            product.Nombre = txtnombre.Text;
            product.Descripcion = txtdescripcion.Text;
            product.Marca = txtmarca.Text;
            product.Precio = float.Parse(txtprecio.Text);
            product.Stock = int.Parse(txtstock.Text);
            product.RutaImagen = txtruta.Text;



            if (edit_indice > -1) //verifica si hay un índice seleccionado
            {
                Productos[edit_indice] = product;
                edit_indice = -1;
            }
            else
            {
                Productos.Add(product); /*al arreglo de Productos le agrego el objeto creado con 
                todos los datos que recolecté*/
            }
            actualizarGrid();//llamamos al procedimiento que guarda en datagrid
            reseteo(); //llamamos al método que resetea
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (edit_indice > -1) //verifica si hay un índice seleccionado
            {
                Productos.RemoveAt(edit_indice);
                edit_indice = -1; //resetea variable a -1
                reseteo();
                actualizarGrid();
            }
            else
            {
                MessageBox.Show("Dar doble click sobre elemento para seleccionar y borrar ");
            }

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            switch (this.dataGridView1.Columns[e.ColumnIndex].Name)
            {
                case "Column6":
                    if (e.Value != null)
                    {
                        try
                        {
                            e.Value = Image.FromFile(e.Value.ToString());
                        }
                        catch (System.IO.FileNotFoundException exc)
                        {

                            e.Value = null;
                        }
                    }
                    break;
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string ruta_imagen = string.Empty;

            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ruta_imagen = openFileDialog.FileName;
                txtruta.Text = ruta_imagen;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
       
        }
    }

}
