using Ardalis.ApiEndpoints;
using CellSystem.Server.Context;
using CellSystem.Shared.Records;
using CellSystem.Shared.Wrapper;
using Microsoft.AspNetCore.Mvc;
using CellSystem.Server.Models;
using Microsoft.EntityFrameworkCore;
using CellSystem.Shared.Routes;
using CellSystem.Shared.Requests;

namespace CellSystem.Server.Endpoints.Facturas;

using Request = FacturarCreateRequest;
using Respuesta = Result<int>;

public class Create : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;
    public Create(IMyDbContext dbContext)
    {
     this.dbContext = dbContext;   
    }
    [HttpPost(FacturarRouteManager.BASE)]
    public override async Task<ActionResult<Respuesta>> HandleAsync(Request request, CancellationToken cancellationToken = default)
    {
        try
        {
            #region Validaciones
            var factura = await dbContext.Facturas.FirstOrDefaultAsync(r => r.Nombre.ToLower() == request.Nombre.ToLower(),cancellationToken);
            if (factura != null)
            return Respuesta.Fail($"Ya existe un rol con el nombre'({request.Nombre})'.");
            #endregion;
            factura  = Facturar.Crear(request);
            dbContext.Facturas.Add(factura);
            await dbContext.SaveChangesAsync(cancellationToken);
            return Respuesta.Success(factura.Id);
           }
        catch (Exception e)
        {
            return Respuesta.Fail(e.Message);
        }
    }

  
}