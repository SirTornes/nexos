using Microsoft.EntityFrameworkCore;
using pruebaNexos.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pruebaNexos.Models
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
            
        }

        public DbSet<Pacientes> Pacientes { get; set; }
        public DbSet<Doctores> Doctores{ get; set; }
        public DbSet<Citas> Citas { get; set; }

    }

}
