using System.Collections.Immutable;
using System.Net;
using CellSystem.Shared.Wrapper;
using CellSystem.Shared.Records;
using CellSystem.Shared.Requests;
using CellSystem.Shared.Routes;
using CellSystem.Client.Extensions;
using System.Net.Http.Json;

namespace CellSystem.Client.Manager;

public interface IProductosManager
{
    Task<ResultList<ProductosRecord>> GetAsync();
    Task<Result<int>> CreateAsync(ProductosCreateRequest request);
    Task<Result<ProductosRecord>> GetByIdAsync(int Id);
    // Task<Result> UpdateAsync(int usuarioRolId, UsuarioRolUpdateRequest request);
}

public class ProductosManager : IProductosManager
{
    private readonly HttpClient httpClient;

    public ProductosManager(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<ResultList<ProductosRecord>> GetAsync()
    {
        try
        {
            var response = await httpClient.GetAsync(ClienteRouteManager.BASE);
            var resultado = await response.ToResultList<ProductosRecord>();
            return resultado;
        }
        catch (Exception e)
        {

            return ResultList<ProductosRecord>.Fail(e.Message);
        }

    }
    public async Task<Result<int>> CreateAsync(ProductosCreateRequest request)
    {
        var response = await httpClient.PostAsJsonAsync (ClienteRouteManager.BASE,request); 
        return await response.ToResult<int>();

    }
// public async Task<Result> UpdateAsync(int usuarioRolId, UsuarioRolUpdateRequest request)
// {
     
//     var response = await httpClient.PutAsJsonAsync($"{ClienteRouteManager.BASE}/{usuarioRolId}", request);
//     return await response.ToResult();
// }



    
  public async Task<Result<ProductosRecord>> GetByIdAsync(int Id)
    {
        var response = await httpClient.GetAsync (ProductosRouteManager.BuildRoute(Id)); 
        return await response.ToResult<ProductosRecord>();

    }

}