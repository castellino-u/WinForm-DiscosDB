using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;

namespace winform_app
{
    public partial class frmAltaDisco : Form
    {
        public frmAltaDisco()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Disco aux = new Disco();
            DiscoNegocio negocio = new DiscoNegocio();

            //capturamos los datos y los mandamos a la base de datos
            try
            { 
                aux.Artista = txtArtista.Text;
                aux.Album = txtTitulo.Text;
                aux.CantidadCanciones = (int)nudCantCanciones.Value;
                aux.UrlImagenTapa = txtUrlImagenTapa.Text;
                aux.Formato = (Edicion)cboFormato.SelectedItem;
                aux.Genero = (Estilo)cboEstilo.SelectedItem;
                aux.FechaLanzamiento = dtpFechaLanzamiento.Value;

                negocio.agregar(aux);
                MessageBox.Show("Agregado exitosamente");
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }



        }

        private void frmAltaDisco_Load(object sender, EventArgs e)
        {
            try
            {
                
                EdicionNegocio edicionNegocio = new EdicionNegocio();
                cboFormato.DataSource = edicionNegocio.listar();


                EstiloNegocio estiloNegocio = new EstiloNegocio();
                cboEstilo.DataSource = estiloNegocio.listar();

                cargarImagen("https://us.123rf.com/450wm/djvstock/djvstock1702/djvstock170212440/72504954-dise%C3%B1o-gr%C3%A1fico-del-ejemplo-aislado-del-vector-del-icono-de-la-m%C3%BAsica-del-vinilo.jpg?ver=6");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

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
    }
}
