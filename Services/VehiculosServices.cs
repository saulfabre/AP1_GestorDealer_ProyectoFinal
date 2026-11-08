using System.Linq.Expressions;
using Aplicada1.Core;
using AP1_GestorDealer_ProyectoFinal.Context;
using AP1_GestorDealer_ProyectoFinal.Models;
using Microsoft.EntityFrameworkCore;

namespace AP1_GestorDealer_ProyectoFinal.Services;

public class VehiculosServices(IDbContextFactory<Contexto> contextFactory
    ) : IServiceResult<Vehiculos, int>
{
    public async Task<Result<Vehiculos?>> Buscar(int vehiculoId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Vehiculos
            .FirstOrDefaultAsync(v => v.VehiculoId == vehiculoId);
    }

    public async Task<Result<List<Vehiculos>>> GetList(Expression<Func<Vehiculos, bool>> criterio)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Vehiculos
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<bool> Existe(int vehiculoId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Vehiculos
            .AnyAsync(v => v.VehiculoId == vehiculoId);
    }

    public async Task<bool> ExisteMatricula(string matricula, int vehiculoId = 0)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Vehiculos.AnyAsync(v =>
            v.Matricula == matricula && v.VehiculoId != vehiculoId);
    }

    public async Task<bool> Insertar(Vehiculos vehiculo)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        contexto.Vehiculos.Add(vehiculo);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Vehiculos vehiculo)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        contexto.Update(vehiculo);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<Result> Eliminar(int vehiculoId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        var eliminado = await contexto.Vehiculos
            .Where(v => v.VehiculoId == vehiculoId)
            .ExecuteDeleteAsync() > 0;
        return Result.Success(eliminado);
    }

    public async Task<Result> Guardar(Vehiculos vehiculo)
    {
        if (!await Existe(vehiculo.VehiculoId))
        {
            return Result.Success(await Insertar(vehiculo));
        }
        else
        {
            return Result.Success(await Modificar(vehiculo));
        }
    }
}
