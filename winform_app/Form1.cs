using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using negocio;
using dominio;

namespace winform_app
{
    public partial class Form1 : Form
    {
        private List<Disco> listaDisco;  //creo el atributo este para poder usarlo de forma mas cómoda 
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargarDatos();


        }

        //evento para que cambie de imagen seleccionando un album
        private void dgvAlbum_SelectionChanged(object sender, EventArgs e)
        {
            Disco seleccionado = (Disco)dgvAlbum.CurrentRow.DataBoundItem;
            //pbAlbum.Load(seleccionado.UrlImagenTapa);
            cargarImagen(seleccionado.UrlImagenTapa);
            //labels 
            lblCantCanciones.Text = seleccionado.CantidadCanciones.ToString();
            lblFormato.Text = seleccionado.Formato.Descripcion;
            lblGenero.Text = seleccionado.Genero.Descripcion;
        }

        //acá voy a hacer un método para seleccionar la imagen de manera separada, encapsulada  
        //modularizamos un método repetido
        private void cargarImagen(string imagen)
        {
            try
            {
                pbAlbum.Load(imagen);
            }
            catch (Exception)
            {
                pbAlbum.Load("https://media.istockphoto.com/id/1147544807/vector/thumbnail-image-vector-graphic.jpg?s=612x612&w=0&k=20&c=rnCKVbdxqkjlcs3xH87-9gocETqpspHFXu5dIGB4wuM=");
                
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaDisco alta = new frmAltaDisco();
            
            alta.ShowDialog();
            cargarDatos();

        }

        private void cargarDatos()
        {
            //generamos la instancia de mi clase contenedora de los métodos para llamar a la database
            DiscoNegocio discoNegocio = new DiscoNegocio();
            //Ahora lo que nos genera ese servicio, debemos traerlo para acá y mandarlo a la interfaz
            //Creamos una lista y la mandamos a los controladores del form
            listaDisco = discoNegocio.listar();

            //Una vez hecho esto, sigue mandar esa lista a mi controlador de la interfaz

            dgvAlbum.DataSource = listaDisco;
            //dgvAlbum.Columns["UrlImagenTapa"].Visible = false; //ocultamos la url que no queremos ver
            //ocultamos las nuevas columnas
            dgvAlbum.Columns["CantidadCanciones"].Visible = false;
            dgvAlbum.Columns["Genero"].Visible = false;
            dgvAlbum.Columns["Formato"].Visible = false;

            dgvAlbum.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; //un poco de diseño

            cargarImagen(listaDisco[0].UrlImagenTapa);

            
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Disco seleccionado = new Disco();
            seleccionado = (Disco)dgvAlbum.CurrentRow.DataBoundItem;
            frmAltaDisco modificar = new frmAltaDisco(seleccionado);
            modificar.ShowDialog();


            cargarDatos();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Disco aux = new Disco();
            try
            {
                DialogResult resultado = MessageBox.Show("¿Seguro deseas eliminar el registro?", "Eliminar", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (resultado == DialogResult.OK)
                {
                    aux = (Disco)dgvAlbum.CurrentRow.DataBoundItem;
                    DiscoNegocio negocio = new DiscoNegocio();
                    negocio.eliminar(aux.Id);
                    cargarDatos();

                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }
    }
}
