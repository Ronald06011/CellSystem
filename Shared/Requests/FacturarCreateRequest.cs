using System.ComponentModel.DataAnnotations;

namespace CellSystem.Shared.Requests;

public class FacturarCreateRequest: ProductosCreateRequest
{
    public string pago { get; set; }=null!;
    public int Total { get; set; }
    public int Descuento { get; set; }
}