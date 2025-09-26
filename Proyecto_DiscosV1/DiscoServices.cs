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
        //Consulta nueva: Select D.Titulo as Album, D.UrlImagenTapa, D.Artista, D.CantidadCanciones, E.Descripcion as Genero, T.Descripcion as Edicion  From DISCOS D, ESTILOS E, TIPOSEDICION T  WHERE D.IdEstilo = E.Id AND D.IdTipoEdicion = T.Id;




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
                comando.CommandText = "Select D.Titulo as Album, D.UrlImagenTapa, D.Artista, D.CantidadCanciones, E.Descripcion as Genero, T.Descripcion as Edicion  From DISCOS D, ESTILOS E, TIPOSEDICION T  WHERE D.IdEstilo = E.Id AND D.IdTipoEdicion = T.Id;";
                //asignamos el comando a la conexión para que sepa a donde se tiene que conectar
                comando.Connection = conexion;
                //Lo siguiente es abrir la conexion
                conexion.Open();
                //Lo siguiente es realizar la lectura y capturar ese objeto que nos devuelve la lectura en el lector
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Disco aux = new Disco();
                    aux.Artista = (string)lector["Artista"];
                    aux.Album = (string)lector["Album"];
                    aux.UrlImagenTapa = (string)lector["UrlImagenTapa"];
                    aux.CantidadCanciones = (int)lector["CantidadCanciones"];
                    //primero creo el objeto  vacio de la propertie de disco 
                    aux.Formato = new Edicion();
                    //luego lo relleno al objeto
                    aux.Formato.Descripcion = (string)lector["Edicion"];

                    aux.Genero = new Estilo();
                    aux.Genero.Descripcion = (string)lector["Genero"];


                    lista.Add(aux);


                }

                conexion.Close();


                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



    }
}
