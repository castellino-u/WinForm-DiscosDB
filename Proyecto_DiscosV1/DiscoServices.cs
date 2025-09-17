using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Proyecto_DiscosV1
{
    internal class DiscoServices
    {
        //consulta sql inicial: 
        //Select D.Titulo as Album, D.UrlImagenTapa, D.Artista From DISCOS D;



        //En esta clase yo voy a crear los métodos de acceso a datos para los albums
        //Estamos trabajando con el patrón MVC o Arquitectura de capas
        //

        public List<Disco> listar()
        {
            List<Disco> lista = new List<Disco>();

            //configuración de la consulta. Para eso de claramos objetos de la librería sqlclient
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector; 
            try
            {
                //Vamos a configurar la cadena de conexión 
                conexion.ConnectionString = "server=.\\SQLEXPRESS; Database=DISCOS_DB; Integrated Security=true";
                //Configuramos el comando, o sea configuramos la acción a realizar en la base de datos
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select D.Titulo as Album, D.UrlImagenTapa, D.Artista From DISCOS D;";


                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



    }
}
