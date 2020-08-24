using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pruebaNexos.Entities;
using pruebaNexos.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace pruebaNexos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitasController : ControllerBase
    {
        private readonly DBContext context;

        public CitasController(DBContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public ResultadoEjecucion Post([FromBody] IEnumerable<Citas> citas)
        {
            ResultadoEjecucion respuesta = new ResultadoEjecucion();
            try
            {
                foreach (var item in citas)
                {
                    context.Citas.Add(item);
                    context.SaveChanges();
                }

                respuesta.codigo = 0;
                respuesta.descripcion = "Registro creado";

                return respuesta;
            }
            catch(Exception ex)
            {
                respuesta.codigo = 100;
                respuesta.descripcion = "Problema en la aplicacion, mensaje: " + ex.Message;

                return respuesta;
            }
            
        }
    }
}
