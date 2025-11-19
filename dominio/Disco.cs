using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Disco
    {
        public int Id { get; set; }
        public string Artista { get; set; }

        public string Album  { get; set; }

        public string UrlImagenTapa { get; set; }

        public int CantidadCanciones { get; set; }
        public DateTime FechaLanzamiento { get; set; }

        public  Estilo Genero { get; set; }
        public Edicion Formato { get; set; }

    }
}
