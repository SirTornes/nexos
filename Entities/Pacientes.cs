using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pruebaNexos.Entities
{
    public class Pacientes
    {
        [Key]
        public int id { get; set; }
        public string pac_cedula { get; set; }
        public string pac_nombre_completo { get; set; }
        public string pac_num_seguro_social { get; set; }
        public string pac_cod_postal { get; set; }
        public string pac_telefono { get; set; }
    }
}
