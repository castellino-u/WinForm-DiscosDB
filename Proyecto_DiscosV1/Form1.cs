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

namespace Proyecto_DiscosV1
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
            //generamos la instancia de mi clase contenedora de los métodos para llamar a la database
            DiscoNegocio discoNegocio = new DiscoNegocio();
            //Ahora lo que nos genera ese servicio, debemos traerlo para acá y mandarlo a la interfaz
            //Creamos una lista y la mandamos a los controladores del form
            listaDisco = discoNegocio.listar();

            //Una vez hecho esto, sigue mandar esa lista a mi controlador de la interfaz

            dgvAlbum.DataSource = listaDisco;
            dgvAlbum.Columns["UrlImagenTapa"].Visible = false; //ocultamos la url que no queremos ver
            //ocultamos las nuevas columnas
            dgvAlbum.Columns["CantidadCanciones"].Visible=false;
            dgvAlbum.Columns["Genero"].Visible = false;
            dgvAlbum.Columns["Formato"].Visible = false;

            dgvAlbum.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; //un poco de diseño

            cargarImagen(listaDisco[0].UrlImagenTapa);

            //Acá cargamos los labels y después repetimos el paso en el selectedChange
            lblCantCanciones.Text = listaDisco[0].CantidadCanciones.ToString();
            lblFormato.Text = listaDisco[0].Formato.Descripcion;
            lblGenero.Text = listaDisco[0].Genero.Descripcion;


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
                throw;
            }
        }

      
    }
}
