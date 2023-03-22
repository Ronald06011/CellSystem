using Ardalis.ApiEndpoints;
using CellSystem.Server.Context;
using CellSystem.Shared.Records;
using CellSystem.Shared.Wrapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CellSystem.Shared.Routes;


namespace CellSystem.Server.Endpoints.Producto;
using Respuesta = Result<ProductosRecord>;
using Request = ProductosRouteManager;
public class GetById : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;
    public GetById(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpGet(ProductosRouteManager.GetById)]
      public override async Task<ActionResult<Respuesta>> HandleAsync([FromRoute] Request request,CancellationToken cancellationToken = default)
    {
       try
       {
        var productos= await dbContext.Producto
        .Where(r=>r.Id == request.Id)
       .Select(productos=>productos.ToRecord())
       .FirstOrDefaultAsync(cancellationToken);

       if(productos==null)
        return Respuesta.Fail($"No fue posible encontrar el rol '{request.Id}'");

        return Respuesta.Success(productos);
       }
       catch(Exception ex)
       {
        return Respuesta.Fail(ex.Message);
       }
    }
        
    }



