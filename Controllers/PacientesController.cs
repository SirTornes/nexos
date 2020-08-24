using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pruebaNexos.Entities;
using pruebaNexos.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace pruebaNexos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private readonly DBContext context;

        public PacientesController(DBContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ResultadoEjecucion<IEnumerable<Pacientes>> Get()
        {
            ResultadoEjecucion<IEnumerable<Pacientes>> respuesta = new ResultadoEjecucion<IEnumerable<Pacientes>>();
            try
            {
                var consulta = context.Pacientes.ToList();
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
            catch(Exception ex)
            {
                respuesta.codigo = 100;
                respuesta.descripcion = "Problema en la aplicacion, mensaje: " + ex.Message;
                respuesta.entidad = null;
                return respuesta;
            }
        }
        
        [HttpGet("{id}")]
        public ResultadoEjecucion<Pacientes> Get(string id)
        {
            ResultadoEjecucion<Pacientes> respuesta = new ResultadoEjecucion<Pacientes>();
            try
            {
                var consulta = context.Pacientes.FirstOrDefault(p => p.pac_cedula == id);
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
        public ResultadoEjecucion Post([FromBody] Pacientes paciente)
        {
            ResultadoEjecucion resultado = new ResultadoEjecucion();
            try
            {
                context.Pacientes.Add(paciente);
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

        [HttpPut("{id}")]
        public ResultadoEjecucion Put(string id, [FromBody] Pacientes paciente)
        {
            ResultadoEjecucion resultado = new ResultadoEjecucion();
            try
            {
                if (paciente.pac_cedula == id)
                {
                    context.Entry(paciente).State = EntityState.Modified;
                    context.SaveChanges();

                    resultado.codigo = 0;
                    resultado.descripcion = "Paciente modificado exitosamente";
                    return resultado;
                }
                else
                {
                    resultado.codigo = 1;
                    resultado.descripcion = "No se pudo actualizar el paciente";
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                resultado.codigo = 100;
                resultado.descripcion = "Problema en la aplicacion, mensaje: " + ex.Message;
                return resultado;
            }
        }

        [HttpDelete("{id}")]
        public ResultadoEjecucion Delete(string id)
        {
            ResultadoEjecucion resultado = new ResultadoEjecucion();
            try
            {
                var paciente = context.Pacientes.FirstOrDefault(p => p.pac_cedula == id);
                if (paciente != null)
                {
                    context.Pacientes.Remove(paciente);
                    context.SaveChanges();

                    resultado.codigo = 0;
                    resultado.descripcion = "Se elimino el paciente";
                    return resultado;
                }
                else
                {
                    resultado.codigo = 1;
                    resultado.descripcion = "No se pudo eliminar el paciente";
                    return resultado;
                }
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
