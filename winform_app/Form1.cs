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

            cbxCampo.Items.Add("Artista");
            cbxCampo.Items.Add("Cantidad de canciones");
            //cbxCampo.Items.Add("");


        }

        //evento para que cambie de imagen seleccionando un album
        private void dgvAlbum_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvAlbum.CurrentRow != null)
            {
                Disco seleccionado = (Disco)dgvAlbum.CurrentRow.DataBoundItem;
                //pbAlbum.Load(seleccionado.UrlImagenTapa);
                cargarImagen(seleccionado.UrlImagenTapa);
                //labels 
                lblCantCanciones.Text = seleccionado.CantidadCanciones.ToString();
                lblFormato.Text = seleccionado.Formato.Descripcion;
                lblGenero.Text = seleccionado.Genero.Descripcion;
            }
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
            dgvAlbum.DataSource = null;
            dgvAlbum.DataSource = listaDisco;
            columnas();
            

            if (listaDisco.Count > 0 )
            {
                cargarImagen(listaDisco[0].UrlImagenTapa);
            }

            
        }
        public void columnas()
        {
            //ocultamos las nuevas columnas
            dgvAlbum.Columns["CantidadCanciones"].Visible = false;
            dgvAlbum.Columns["Genero"].Visible = false;
            dgvAlbum.Columns["Formato"].Visible = false;
            dgvAlbum.Columns["UrlImagenTapa"].Visible = false;
            dgvAlbum.Columns["Estado"].Visible = false;

            dgvAlbum.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; //un poco de diseño
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if(dgvAlbum.CurrentRow != null)
            {
                Disco seleccionado = new Disco();
                seleccionado = (Disco)dgvAlbum.CurrentRow.DataBoundItem;
                frmAltaDisco modificar = new frmAltaDisco(seleccionado);
                modificar.ShowDialog();

            }


            cargarDatos();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminar();
        }

        private void btnEliminarLogico_Click_1(object sender, EventArgs e)
        {
            eliminar(true);
        }

        public void eliminar(bool logico = false)
        {
            Disco aux = new Disco();
            try
            {
                DialogResult resultado = MessageBox.Show("¿Seguro deseas eliminar el registro?", "Eliminar", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (resultado == DialogResult.OK)
                {
                    aux = (Disco)dgvAlbum.CurrentRow.DataBoundItem;
                    DiscoNegocio negocio = new DiscoNegocio();
                    if (logico)
                    {
                        negocio.eliminarLogico(aux.Id);
                    }
                    else
                    {
                        negocio.eliminar(aux.Id);

                    }
                    cargarDatos();

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void txtfiltroRapido_TextChanged(object sender, EventArgs e)
        {
            List<Disco> listaFiltrada;
            string filtro = txtfiltroRapido.Text;
            int numero;

            if (int.TryParse(filtro, out numero))
            {


                listaFiltrada = listaDisco.FindAll(x => x.Id == numero);

            }
            else if (filtro != "")
            {
                listaFiltrada = listaDisco.FindAll(x => x.Artista.ToUpper().Contains(filtro.ToUpper()));
            }
            else
            {
                listaFiltrada = listaDisco;
            }

            dgvAlbum.DataSource = null;
            dgvAlbum.DataSource = listaFiltrada;
            columnas();
        }


        private void btnFiltroAvanzado_Click(object sender, EventArgs e)
        {
            if (cbxCampo.SelectedItem == null || cboCriterio.SelectedItem == null )
            {
                MessageBox.Show("Por favor seleccione campo y criterio");
                return;
            }
            string campo = cbxCampo.SelectedItem.ToString();
            string criterio = cboCriterio.SelectedItem.ToString();
            string filtro = txtFiltro.Text;

            DiscoNegocio negocio = new DiscoNegocio();
            dgvAlbum.DataSource = null;
            dgvAlbum.DataSource = negocio.filtrar(campo, criterio, filtro);
            columnas();
        }

       

        private void cbxCampo_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string campo = cbxCampo.SelectedItem.ToString(); ;
            cboCriterio.Items.Clear();

            if (campo == "Artista")
            {
                cboCriterio.Items.Add("Empieza con");
                cboCriterio.Items.Add("Termina con");
                cboCriterio.Items.Add("Contiene");

            }
            else
            {


                cboCriterio.Items.Add("Mayor a");
                cboCriterio.Items.Add("Menor a");
                cboCriterio.Items.Add("Igual a");

            }
        }

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            cargarDatos();
        }
    }
}
