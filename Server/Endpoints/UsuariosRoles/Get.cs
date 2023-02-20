using Ardalis.ApiEndpoints;
using CellSystem.Server.Context;
using CellSystem.Shared.Records;
using CellSystem.Shared.Wrapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CellSystem.Server.Endpoints.UsuariosRoles;

using Repuesta = ResultList<UsuarioRolRecord>;

public class Get : EndpointBaseAsync.WithoutRequest.WithActionResult<Repuesta>
{
    private readonly IMyDbContext dbContext;
    public Get(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public override async Task<ActionResult<Repuesta>>HandleAsync(CancellationToken cancellationToken)
    {
        try{
        var roles =  await dbContext.UsuariosRoles
        .Select(rol=>rol.ToRecord())
        .ToListAsync(cancellationToken);
        return Repuesta.Success(roles);
        }
        catch(Exception ex){
            return Repuesta.Fail(ex.Message);
        }
        
    }


}
