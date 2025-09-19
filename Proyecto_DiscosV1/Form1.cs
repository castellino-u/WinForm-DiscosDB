using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_DiscosV1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //generamos la instancia de mi clase contenedora de los métodos para llamar a la database
            DiscoServices discoServices = new DiscoServices();
            //Ahora lo que nos genera ese servicio, debemos traerlo para acá y mandarlo a la interfaz
            //Creamos una lista y la mandamos a los controladores del form
            List<Disco> discos = discoServices.listar();

            //Una vez hecho esto, sigue mandar esa lista a mi controlador de la interfaz
            dgvAlbum.DataSource = discos;


        }
    }
}
