using System.ComponentModel.DataAnnotations;
using CellSystem.Shared.Records;
using CellSystem.Shared.Requests;
namespace  CellSystem.Server.Models;

public class Productos{
    [Key]
    public string Nombre{get; set;}= null!;
    public string Modelo { get; set; }= null!;

    public string Marca { get; set; } = null!;

    public string Tipo { get; set; }= null!;

    public int Cantidad{ get; set; }

    public int Precio { get; set; }

    public int valor { get; set; }
     public static Productos Crear (ProductosCreateRequest request)
        {
                return new Productos(){
                        Nombre =  request.Nombre,
                        Modelo=request.Modelo,
                        Marca = request.Marca,
                        Tipo=request.Tipo,
                        Cantidad=request.Cantidad,
                        Precio=request.Precio,
                        valor=request.valor
                };
        }
    
     public ProductosRecord ToRecord() 
    {
      return new ProductosRecord(Nombre,Marca,Modelo,Tipo,Cantidad,Precio,valor);
    }
}