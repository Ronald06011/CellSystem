using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using CellSystem.Server.Models;
namespace CellSystem.Server.Context;

public interface IMyDbContext
{
    DbSet<UsuarioRol> UsuariosRoles { get; set; }
    DbSet<Usuario> Usuarios { get; set; }
    DbSet<Cliente> Clientes {get; set;} 
    DbSet<Facturar>Facturas{get; set;} 
    DbSet<Productos>Producto {get; set;} 
    

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

public class MyDbContext : DbContext, IMyDbContext
{
    private readonly IConfiguration config;

    public MyDbContext(IConfiguration _config)
    {
        config = _config;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

    {
        optionsBuilder.UseSqlServer(config.GetConnectionString("CellSystem"));
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }

    #region Tabla de la BD.
    public DbSet<UsuarioRol> UsuariosRoles { get; set; } = null!;
    public DbSet<Usuario> Usuarios { get; set; } = null!;
    
    
    public DbSet<Cliente> Clientes {get; set;} = null!;
    public DbSet<Facturar>Facturas{get; set;} = null!;
    public DbSet<Productos>Producto {get; set;} = null!;
    
    
    
    #endregion
}