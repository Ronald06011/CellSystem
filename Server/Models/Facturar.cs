using CellSystem.Shared.Records;
using CellSystem.Shared.Requests;
using System.ComponentModel.DataAnnotations;

namespace   CellSystem.Server.Models;

public class Facturar: Productos
{
    public string Pago { get; set; }=null!;
    public int Total { get; set; }
    public int Descuento { get; set; }

      public static Facturar Crear (FacturarCreateRequest request)
        {
                return new Facturar(){
                       
                       Pago = request.Pago,
                       Total=request.Total,
                       Descuento=request.Descuento

                };

        }
        public new FacturarRecord ToRecord()
        {
                return new FacturarRecord(Pago,Total,Descuento);
        }
}

