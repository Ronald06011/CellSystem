using Ardalis.ApiEndpoints;
using CellSystem.Server.Context;
using CellSystem.Shared.Records;
using CellSystem.Shared.Wrapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CellSystem.Shared.Routes;
using CellSystem.Server.Models;

namespace CellSystem.Server.Endpoints.UsuariosRoles;

using Repuesta = ResultList<UsuarioRolRecord>;

public class Get : EndpointBaseAsync.WithoutRequest.WithActionResult<Repuesta>
{
    private readonly IMyDbContext dbContext;
    public Get(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpGet(UsuarioRolRouteManager.BASE)]
    public override async Task<ActionResult<Repuesta>>HandleAsync(CancellationToken cancellationToken)
    {
        try{
        var NumeroDeRolesExistentes = 
        await dbContext.UsuariosRoles.CountAsync() ;
        NumeroDeRolesExistentes++;

        var rol = UsuarioRol.Crear(new Shared.Requests.UsuarioRolCreateRequest(){
            Nombre = NumeroDeRolesExistentes.ToString(),
            PermisoParaCrear = true,
            PermisoParaEditar = false,
            PermisoParaEliminar = false
        });

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
