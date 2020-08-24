using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pruebaNexos.Entities
{
    public class Doctores
    {
        [Key]
        public int id { get; set; }
        public string doc_cedula { get; set; }
        public string doc_nombre_completo { get; set; }
        public string doc_especialidad { get; set; }
        public string doc_num_credencial { get; set; }
        public string doc_hospital { get; set; }
    }
}
