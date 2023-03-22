using Ardalis.ApiEndpoints;
using CellSystem.Server.Context;
using CellSystem.Shared.Records;
using CellSystem.Shared.Wrapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CellSystem.Shared.Routes;
using CellSystem.Server.Models;

namespace CellSystem.Server.Endpoints.Producto;
using Respuesta = ResultList<ProductosRecord>;

public class Get : EndpointBaseAsync.WithoutRequest.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;
    public Get(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpGet(ProductosRouteManager.BASE)]
    public override async Task<ActionResult<Respuesta>>HandleAsync(CancellationToken cancellationToken = default)
    {
        try
        {
        var productos =  await dbContext.Producto
        .Select(producto=>producto.ToRecord())
        .ToListAsync(cancellationToken);
       
        return Respuesta.Success(productos);
        }
        catch(Exception ex){
            return Respuesta.Fail(ex.Message);
        }
        
    }


}
