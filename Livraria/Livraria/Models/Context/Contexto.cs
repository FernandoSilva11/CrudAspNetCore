using Livraria.Models.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Models.Context
{
    public class Contexto :DbContext
    {
        
        public Contexto(DbContextOptions<Contexto> options) :base(options)
        {
        }

        public DbSet<Livros> Livro { get; set; }

    }
}
