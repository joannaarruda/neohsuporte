using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using neohsuporte.Models;

namespace neohsuporte.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Hospital>Hospitals { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<PedidoSuporte> PedidoSuportes { get; set; }
        public DbSet<AtenderPedido> AtenderPedidos { get; set; }
    }
}
