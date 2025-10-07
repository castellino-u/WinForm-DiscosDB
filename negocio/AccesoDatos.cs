using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace negocio
{
    internal class AccesoDatos
    {
        //esta clase la usaremos para acceder a los datos sin la necesidad de declarar los objetos por todos lados, los objetos que usaremos para las futuras conexiones

        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;
        //property para poder acceder al lector desde otro lado, pero solo como lectura
        public SqlDataReader Lector 
        {
            get { return lector; } 
        }


        //luego deberemos ir creando los métodos para poder establecer la conexión

        //definimos el constructor de clase  que al momento de instanciar un objeto, settee y haga la conexión

        public AccesoDatos()
        {
            conexion = new SqlConnection("server=.\\SQLEXPRESS; Database=DISCOS_DB; Integrated Security=true");
            comando = new SqlCommand();

        }

        //Función para configurar la consulta

        public void setearConsulta(string consulta)  //de este modo encapsulamos el darle un tipo y la consulta al comando
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        //Ejecutar la lectura

        public void ejecutarLectura() 
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        //Cerrar la conexión

        public void cerrarConexion()
        {
            if (lector != null) { lector.Close(); } //También hay que cerrar el lector
            conexion.Close();
        }








    }
}
