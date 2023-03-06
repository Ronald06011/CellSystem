using System.Security;
using CellSystem.Shared.Wrapper;
using CellSystem.Shared.Records;
using CellSystem.Shared.Routes;
namespace CellSystem.Client.Infraestructure.Managers;

public class UsuarioRolManager
{
    private readonly HttpClient HttpClient;

    public UsuarioRolManager(HttpClient _httpClient)
    {
        HttpClient = _httpClient;
    }

    public async Task<ResultList<UsuarioRolRecord>> GetAsync()
    {
        var respuesta = await HttpClient.GetAsync(UsuarioRolRouteManager.BASE);
        var  contenido = await respuesta.Content.ReadAsStringAsync();
        return 

    }

}