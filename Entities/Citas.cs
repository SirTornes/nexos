using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pruebaNexos.Entities
{
    public class Citas
    {
        [Key]
        public int id { get; set; }

        public string Pacientes { get; set; }

        public string Doctores { get; set; }
    }
}
