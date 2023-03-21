using System.Collections.Immutable;
using System.Net;
using CellSystem.Shared.Wrapper;
using CellSystem.Shared.Records;
using CellSystem.Shared.Requests;
using CellSystem.Shared.Routes;
using CellSystem.Client.Extensions;
using System.Net.Http.Json;

namespace CellSystem.Client.Manager;

public interface IClienteManager
{
    Task<ResultList<ClienteRecord>> GetAsync();
    Task<Result<int>> CreateAsync(ClienteCreateRequest request);
    Task<Result<ClienteRecord>> GetByIdAsync(int Id);
    // Task<Result> UpdateAsync(int usuarioRolId, UsuarioRolUpdateRequest request);
}

public class ClienteManager : IClienteManager
{
    private readonly HttpClient httpClient;

    public ClienteManager(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<ResultList<ClienteRecord>> GetAsync()
    {
        try
        {
            var response = await httpClient.GetAsync(ClienteRouteManager.BASE);
            var resultado = await response.ToResultList<ClienteRecord>();
            return resultado;
        }
        catch (Exception e)
        {

            return ResultList<ClienteRecord>.Fail(e.Message);
        }

    }
    public async Task<Result<int>> CreateAsync(ClienteCreateRequest request)
    {
        var response = await httpClient.PostAsJsonAsync (ClienteRouteManager.BASE,request); 
        return await response.ToResult<int>();

    }
// public async Task<Result> UpdateAsync(int usuarioRolId, UsuarioRolUpdateRequest request)
// {
     
//     var response = await httpClient.PutAsJsonAsync($"{ClienteRouteManager.BASE}/{usuarioRolId}", request);
//     return await response.ToResult();
// }



    
  public async Task<Result<ClienteRecord>> GetByIdAsync(int Id)
    {
        var response = await httpClient.GetAsync (ClienteRouteManager.BuildRoute(Id)); 
        return await response.ToResult<ClienteRecord>();

    }

}