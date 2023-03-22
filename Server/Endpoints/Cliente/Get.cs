using Ardalis.ApiEndpoints;
using CellSystem.Server.Context;
using CellSystem.Shared.Records;
using CellSystem.Shared.Wrapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CellSystem.Shared.Routes;
using CellSystem.Server.Models;

namespace CellSystem.Server.Endpoints.Clientes;
using Respuesta = ResultList<ClienteRecord>;

public class Get : EndpointBaseAsync.WithoutRequest.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;
    public Get(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpGet(ClienteRouteManager.BASE)]
    public override async Task<ActionResult<Respuesta>>HandleAsync(CancellationToken cancellationToken = default)
    {
        try
        {
        var clientes =  await dbContext.Clientes
        .Select(cliente=>cliente.ToRecord())
        .ToListAsync(cancellationToken);
       
        return Respuesta.Success(clientes);
        }
        catch(Exception ex){
            return Respuesta.Fail(ex.Message);
        }
        
    }


}
