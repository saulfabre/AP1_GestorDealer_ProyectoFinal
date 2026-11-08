using AP1_GestorDealer_ProyectoFinal.Models;
using Microsoft.EntityFrameworkCore;

namespace AP1_GestorDealer_ProyectoFinal.Context;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options)
        : base(options)
    {

    }

    public DbSet<Vehiculos> Vehiculos { get; set; }
}
