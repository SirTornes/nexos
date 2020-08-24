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
    public class DoctoresController : ControllerBase
    {
        private readonly DBContext context;

        public DoctoresController(DBContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ResultadoEjecucion<IEnumerable<Doctores>> Get()
        {
            ResultadoEjecucion<IEnumerable<Doctores>> respuesta = new ResultadoEjecucion<IEnumerable<Doctores>>();
            try
            {
                var consulta = context.Doctores.ToList();
                if (consulta.Count > 0)
                {
                    respuesta.codigo = 0;
                    respuesta.descripcion = "Consulta exitosa";
                    respuesta.entidad = consulta;
                }
                else
                {
                    respuesta.codigo = 1;
                    respuesta.descripcion = "No se encontraron datos";
                    respuesta.entidad = null;
                }
                return respuesta;
            }
            catch (Exception ex)
            {
                respuesta.codigo = 100;
                respuesta.descripcion = "Problema en la aplicacion, mensaje: " + ex.Message;
                respuesta.entidad = null;
                return respuesta;
            }
        }

        [HttpGet("{id}")]
        public ResultadoEjecucion<Doctores> Get(string id)
        {
            ResultadoEjecucion<Doctores> respuesta = new ResultadoEjecucion<Doctores>();
            try
            {
                var consulta = context.Doctores.FirstOrDefault(p => p.doc_cedula == id);
                if (consulta != null)
                {
                    respuesta.codigo = 0;
                    respuesta.descripcion = "Consulta exitosa";
                    respuesta.entidad = consulta;
                }
                else
                {
                    respuesta.codigo = 1;
                    respuesta.descripcion = "No se encontraron datos";
                    respuesta.entidad = null;
                }
                return respuesta;
            }
            catch (Exception ex)
            {
                respuesta.codigo = 100;
                respuesta.descripcion = "Problema en la aplicacion, mensaje: " + ex.Message;
                respuesta.entidad = null;
                return respuesta;
            }
        }

        [HttpPost]
        public ResultadoEjecucion Post([FromBody] Doctores doctor)
        {
            ResultadoEjecucion resultado = new ResultadoEjecucion();
            try
            {
                context.Doctores.Add(doctor);
                context.SaveChanges();

                resultado.codigo = 0;
                resultado.descripcion = "Paciente creado exitosamente";
                return resultado;
            }
            catch (Exception ex)
            {
                resultado.codigo = 100;
                resultado.descripcion = "Problema en la aplicacion, mensaje: " + ex.Message;
                return resultado;
            }
        }

    }
}
