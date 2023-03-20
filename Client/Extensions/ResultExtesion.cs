using CellSystem.Shared.Wrapper;
using Newtonsoft.Json;

namespace CellSystem.Client.Extensions;

internal static class ResultExtension
{
    internal static async Task<Result> ToResult(this HttpResponseMessage response)
    {
        var repuesta_a_texto = await response.Content.ReadAsStringAsync();
        var objecto = JsonConvert.DeserializeObject<Result>(repuesta_a_texto);
        return objecto!;
    }
    internal static async Task<Result<T>> ToResult<T>(this HttpResponseMessage response)
    {

        var repuesta_a_texto = await response.Content.ReadAsStringAsync();
        var objecto = JsonConvert.DeserializeObject<Result<T>>(repuesta_a_texto);
        return objecto!;
    }
    internal static async Task<ResultList<T>> ToResultList<T>(this HttpResponseMessage response)
    {
        var repuesta_a_texto = await response.Content.ReadAsStringAsync();
        var objecto = JsonConvert.DeserializeObject<ResultList<T>>(repuesta_a_texto);
        return objecto!;
    }
}