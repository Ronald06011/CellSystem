using Ardalis.ApiEndpoints;
using CellSystem.Server.Context;
using CellSystem.Shared.Records;
using CellSystem.Shared.Wrapper;
using Microsoft.AspNetCore.Mvc;
using CellSystem.Server.Models;
using Microsoft.EntityFrameworkCore;
using CellSystem.Shared.Routes;
using CellSystem.Shared.Requests;

namespace CellSystem.Server.Endpoints.Clientes;

using Request = ClienteCreateRequest;
using Respuesta = Result<int>;

public class Create : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbContext;
    public Create(IMyDbContext dbContext)
    {
     this.dbContext = dbContext;   
    }
    [HttpPost(ClienteRouteManager.BASE)]
    public override async Task<ActionResult<Respuesta>> HandleAsync(Request request, CancellationToken cancellationToken = default)
    {
        try
        {
            #region Validaciones
            var cliente = await dbContext.Clientes.FirstOrDefaultAsync(r => r.Nombre.ToLower() == request.Nombre.ToLower(),cancellationToken);
            if (cliente  != null)
            return Respuesta.Fail($"Ya existe un rol con el nombre'({request.Nombre})'.");
            #endregion;
            cliente  = Cliente.Crear(request);
            dbContext.Clientes.Add(cliente);
            await dbContext.SaveChangesAsync(cancellationToken);
            return Respuesta.Success(cliente.Id);
           }
        catch (Exception e)
        {
            return Respuesta.Fail(e.Message);
        }
    }

  
}