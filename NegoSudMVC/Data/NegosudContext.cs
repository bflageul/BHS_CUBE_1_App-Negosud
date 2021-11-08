using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NegoSudMVC.Data;
using NegoSudMVC.Models;

namespace NegoSudMVC.Data
{
    public class NegosudContext : DbContext
    {
        public NegosudContext(DbContextOptions<NegosudContext> options)
        : base(options)
        {
        }
        public DbSet<Supplier> Supplier { get; set; }
    }
}
