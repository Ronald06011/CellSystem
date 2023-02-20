using Ardalis.ApiEndpoints;
using CellSystem.Server.Context;
using CellSystem.Shared.Records;
using CellSystem.Shared.Wrapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CellSystem.Server.Endpoints.UsuarioRoles;

using Respuesta = ResultList<UsuarioRolRecord>;
public class Get : EndpointBaseAsync.WithoutRequest.WithActionResult<Respuesta>
{
    private readonly IMyDbContext dbcontext;

    public Get(IMyDbContext dbcontext)
    {
        this.dbcontext = dbcontext;
    }

    public overside async async Task<ActionResult<Respuesta>> handleAsync(CancellationToken cancellation)
    {
        var roles = await dbcontext.UsuariosRoles
        .Select(rol=roles.toRecord())
        .toListAsync(CancellationToken);
        return Respuesta.Success(roles)
    }
}
