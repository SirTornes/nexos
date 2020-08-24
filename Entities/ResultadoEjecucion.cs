using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pruebaNexos.Entities
{
    public class ResultadoEjecucion
    {
        public int codigo { get; set; }
        public string descripcion { get; set; }
    }

    public class ResultadoEjecucion<T>
    {
        public int codigo { get; set; }
        public string descripcion { get; set; }
        public T entidad { get; set; }
    }
}
