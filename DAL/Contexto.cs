
using Entities;
using System;
using System.Data.Entity;

namespace DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Usuarios> Usuarios { get; set; }

        public Contexto() : base("ConStr")
        {

        }
    }
}