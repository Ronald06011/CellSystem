using CellSystem.Shared.Records;
using CellSystem.Shared.Requests;
using System.ComponentModel.DataAnnotations;

namespace   CellSystem.Server.Models;

public class facturar: Productos
{
    public string pago { get; set; }=null!;
    public int Total { get; set; }
    public int Descuento { get; set; }

      public static facturar Crear (FacturarCreateRequest request)
        {
                return new facturar(){
                       
                       pago = request.pago,
                       Total=request.Total,
                       Descuento=request.Descuento

                };

        }

}

