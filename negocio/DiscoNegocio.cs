using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;

namespace negocio
{
    public class DiscoNegocio
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
                comando.CommandText = "Select D.FechaLanzamiento ,D.Id, D.IdEstilo, D.IdTipoEdicion , D.Titulo as Album, D.UrlImagenTapa, D.Artista, D.CantidadCanciones, E.Descripcion as Genero, T.Descripcion as Edicion  From DISCOS D, ESTILOS E, TIPOSEDICION T  WHERE D.IdEstilo = E.Id AND D.IdTipoEdicion = T.Id;\r\n\r\n";
                //asignamos el comando a la conexión para que sepa a donde se tiene que conectar
                comando.Connection = conexion;
                //Lo siguiente es abrir la conexion
                conexion.Open();
                //Lo siguiente es realizar la lectura y capturar ese objeto que nos devuelve la lectura en el lector
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Disco aux = new Disco();
                    aux.Id = (int)lector["Id"];
                    aux.Artista = (string)lector["Artista"];
                    aux.Album = (string)lector["Album"];

                    if (!(lector["UrlImagenTapa"] is DBNull))
                    {
                        aux.UrlImagenTapa = (string)lector["UrlImagenTapa"];

                    }
                    aux.CantidadCanciones = (int)lector["CantidadCanciones"];
                    //primero creo el objeto  vacio de la propertie de disco 
                    aux.Formato = new Edicion();
                    //luego lo relleno al objeto
                    if (!(lector["IdTipoEdicion"] is DBNull))
                    {
                        aux.Formato.Id = (int)lector["IdTipoEdicion"];

                    }
                    if (!(lector["Edicion"] is DBNull))
                    {
                        aux.Formato.Descripcion = (string)lector["Edicion"];
                    }
                    
                    aux.Genero = new Estilo();

                    if (!(lector["IdEstilo"] is DBNull))
                    {
                        aux.Genero.Id = (int)lector["IdEstilo"];

                    }

                    if (!(lector["Genero"] is DBNull))
                    {
                        aux.Genero.Descripcion = (string)lector["Genero"];
                    }

                    aux.FechaLanzamiento = (DateTime)lector["FechaLanzamiento"];

                    lista.Add(aux);


                }
                //lector.Close();
                conexion.Close();


                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public void agregar( Disco disc)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("insert into DISCOS(Titulo, FechaLanzamiento, CantidadCanciones, UrlImagenTapa, IdEstilo, IdTipoEdicion, Artista) values ( @titulo , @fecha, @cantCanciones, @urlImagenTapa , @IdEstilo, @IdTipoEdicion, @Artista);");
                datos.setearParametros("@titulo", disc.Album );
                datos.setearParametros("@fecha", disc.FechaLanzamiento );
                datos.setearParametros("@cantCanciones", disc.CantidadCanciones);
                datos.setearParametros("@urlImagenTapa", disc.UrlImagenTapa );
                datos.setearParametros("@IdEstilo", disc.Genero.Id );
                datos.setearParametros("@IdTipoEdicion", disc.Formato.Id );
                datos.setearParametros("@Artista", disc.Artista );

                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

        public void modificar(Disco disc)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update DISCOS set Titulo = @titulo, FechaLanzamiento = @fechalan, CantidadCanciones = @cantcanciones, UrlImagenTapa = @urlImg, IdEstilo = @idEstilo, IdTipoEdicion = @idTipoEdicion, Artista = @artista Where Id = @id;");
                datos.setearParametros("@titulo", disc.Album);
                datos.setearParametros("@fechalan", disc.FechaLanzamiento);
                datos.setearParametros("@cantcanciones", disc.CantidadCanciones);
                datos.setearParametros("@urlImg", disc.UrlImagenTapa);
                datos.setearParametros("@idEstilo", disc.Genero.Id);
                datos.setearParametros("@idTipoEdicion", disc.Formato.Id);
                datos.setearParametros("@artista", disc.Artista);
                datos.setearParametros("@id", disc.Id);

                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally 
            {
                datos.cerrarConexion();
            }

        }

    }
}
