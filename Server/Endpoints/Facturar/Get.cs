using Ardalis.ApiEndpoints;
using CellSystem.Server.Context;
using CellSystem.Shared.Records;
using CellSystem.Shared.Wrapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CellSystem.Shared.Routes;
using CellSystem.Server.Models;

namespace CellSystem.Server.Endpoints.Facturas;
using Respuesta = ResultList<FacturarRecord>;

public class Get : EndpointBaseAsync.WithoutRequest.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;
    public Get(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpGet(FacturarRouteManager.BASE)]
    public override async Task<ActionResult<Respuesta>>HandleAsync(CancellationToken cancellationToken = default)
    {
        try
        {
        var facturas =  await dbContext.Facturas
        .Select(factura=>factura.ToRecord())
        .ToListAsync(cancellationToken);
       
        return Respuesta.Success(facturas);
        }
        catch(Exception ex){
            return Respuesta.Fail(ex.Message);
        }
        
    }


}
