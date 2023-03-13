using Ardalis.ApiEndpoints;
using CellSystem.Server.Context;
using CellSystem.Shared.Records;
using CellSystem.Shared.Wrapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CellSystem.Shared.Routes;
using CellSystem.Server.Models;

namespace CellSystem.Server.Endpoints.UsuariosRoles;
using Repuesta = Result<UsuarioRolRecord>;
using Request = UsuarioRolRouteManager;
public class GetById : EndpointBaseAsync.WithRequest<Request>.WithActionResult<Repuesta>
{
    private readonly IMyDbContext dbContext;
    public GetById(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpGet(UsuarioRolRouteManager.GetById)]
    public override async Task<ActionResult<Repuesta>>HandleAsync([FromRoute]Request request,CancellationToken cancellationToken)
    {
        try{
        // var NumeroDeRolesExistentes = 
        // await dbContext.UsuariosRoles.CountAsync() ;
        // NumeroDeRolesExistentes++;

        // var rol = UsuarioRol.Crear(new Shared.Requests.UsuarioRolCreateRequest(){
        //     Nombre = NumeroDeRolesExistentes.ToString(),
        //     PermisoParaCrear = true,
        //     PermisoParaEditar = false,
        //     PermisoParaEliminar = false
        // });
        //Insert Into
        // dbContext.UsuariosRoles.Add(rol);
        // await dbContext.SaveChangesAsync(cancellationToken);
        
        var rol=  await dbContext.UsuariosRoles
        .Where(r=>r.Id == request.Id)
        .Select(rol=>rol.ToRecord())
        .FirstOrDefaultAsync(cancellationToken);
       
        if (rol==null)
        return Repuesta.Fail($"No fue posible encontrar el rol'{request.Id}'");
        return Repuesta.Success(rol);
        }
        catch(Exception ex){
            return Repuesta.Fail(ex.Message);
        }
        
    }


}
