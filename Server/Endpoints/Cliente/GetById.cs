using Ardalis.ApiEndpoints;
using CellSystem.Server.Context;
using CellSystem.Shared.Records;
using CellSystem.Shared.Wrapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CellSystem.Shared.Routes;


namespace CellSystem.Server.Endpoints.Clientes;
using Respuesta = Result<ClienteRecord>;
using Request = ClienteRouteManager;
public class GetById : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;
    public GetById(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpGet(ClienteRouteManager.GetById)]
      public override async Task<ActionResult<Respuesta>> HandleAsync([FromRoute] Request request,CancellationToken cancellationToken = default)
    {
       try
       {
        var clientes = await dbContext.Clientes
        .Where(r=>r.Id == request.Id)
       .Select(clientes=>clientes.ToRecord())
       .FirstOrDefaultAsync(cancellationToken);

       if(clientes==null)
        return Respuesta.Fail($"No fue posible encontrar el Cliente '{request.Id}'");

        return Respuesta.Success(clientes);
       }
       catch(Exception ex)
       {
        return Respuesta.Fail(ex.Message);
       }
    }
        
    }



