using System.Net;
using CellSystem.Shared.Wrapper;
using CellSystem.Shared.Records;
using CellSystem.Shared.Routes;
using CellSystem.Client.Extensions;

namespace CellSystem.Client.Manager;

public interface IUsuarioRolManager
{
    Task<ResultList<UsuarioRolRecord>> GetAsync();
}

public class UsuarioRolManager : IUsuarioRolManager
{
    private readonly HttpClient httpClient;

    public UsuarioRolManager(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<ResultList<UsuarioRolRecord>> GetAsync()
    {
        try
        {
            var response = await httpClient.GetAsync(UsuarioRolRouteManager.BASE);
            var resultado = await response.ToResultList<UsuarioRolRecord>();
            return resultado;
        }
        catch (Exception e)
        {

            return ResultList<UsuarioRolRecord>.Fail(e.Message);
        }

    }
}