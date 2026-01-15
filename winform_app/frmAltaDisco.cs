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
        //esta variable en null es la que se usará como bandera al principio
        private Disco disco = null;
        public frmAltaDisco()
        {
            InitializeComponent();
            Text = "Agregar disco";
        }

        public frmAltaDisco(Disco seleccionado) {

            InitializeComponent();
            Text = "Modificar Disco";
            disco = seleccionado;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
            DiscoNegocio negocio = new DiscoNegocio();

            //capturamos los datos y los mandamos a la base de datos
            try
            { 
                if(disco == null) { 
                    disco = new Disco();
                }
                
                disco.Artista = txtArtista.Text;
                disco.Album = txtTitulo.Text;
                disco.CantidadCanciones = (int)nudCantCanciones.Value;
                disco.UrlImagenTapa = txtUrlImagenTapa.Text;
                disco.Formato = (Edicion)cboFormato.SelectedItem;
                disco.Genero = (Estilo)cboEstilo.SelectedItem;
                disco.FechaLanzamiento = dtpFechaLanzamiento.Value;

                if (disco.Id != 0)
                {
                    negocio.modificar(disco);
                    MessageBox.Show("Modificado exitosamente");
                }
                else
                {
                    negocio.agregar(disco);
                    MessageBox.Show("Agregado exitosamente");
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmAltaDisco_Load(object sender, EventArgs e)
        {
                EstiloNegocio estiloNegocio = new EstiloNegocio();
                EdicionNegocio edicionNegocio = new EdicionNegocio();
                cargarImagen("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRjA3GBpYTbg-_qo-aZPZBQhnAqxM-u2Mh3S9jesHtY4W_v8R8-JKo16JcEmpQGUMm_Wbk&usqp=CAU");

            try
            {
                //rellenamos los combo box con las listas de estilo y negocio 
                cboFormato.DataSource = edicionNegocio.listar();
                //vamos a enlazar los datos en el comboBox para poder mostrar un dato preseleccionado
                cboFormato.ValueMember = "Id";
                cboFormato.DisplayMember = "Descripcion";

                cboEstilo.DataSource = estiloNegocio.listar();
                cboEstilo.ValueMember = "Id";
                cboEstilo.DisplayMember = "Descripcion";

                if (disco != null)
                {
                    btnAgregar.Text = "Guardar";
                    //Acá vamos a tener que precargar todos los datos en las estructuras de control 

                    txtArtista.Text = disco.Artista;
                    txtTitulo.Text = disco.Album;
                    txtUrlImagenTapa.Text = disco.UrlImagenTapa;
                    nudCantCanciones.Value = disco.CantidadCanciones;
                    dtpFechaLanzamiento.Value = disco.FechaLanzamiento;
                    cargarImagen(disco.UrlImagenTapa);
                    cboFormato.SelectedValue = disco.Formato.Id;
                    cboEstilo.SelectedValue = disco.Genero.Id;

                }
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
        private void txtUrlImagenTapa_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtUrlImagenTapa.Text);
        }
    }
}
