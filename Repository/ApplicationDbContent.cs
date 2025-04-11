using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RpgApi.Models;

namespace RpgApi.Repository;

public class ApplicationDbContext : DbContext
{
    public DbSet<Personagem> Personagens { get; set; }
    public DbSet<ItemMagico> ItensMagicos { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {

    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Personagem>()
            .HasMany(e => e.ItensMagicos)
            .WithOne(e => e.Personagem);
        
        modelBuilder.Entity<ItemMagico>()
            .HasOne(e => e.Personagem)
            .WithMany(e => e.ItensMagicos); 
        
        base.OnModelCreating(modelBuilder);
    }

}
