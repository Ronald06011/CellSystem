using System.ComponentModel.DataAnnotations;

namespace CellSystem.Shared.Requests;
 
 public class ProductosCreateRequest
 {
   public int Id { get; set; }
    [Required (ErrorMessage="Debe Proporcionar un Nombre")]
    public string Nombre{get; set;}= null!;
    
    public string Modelo { get; set; }= null!;

    public string Marca { get; set; } = null!;

    public string Tipo { get; set; }= null!;

    public int Cantidad{ get; set; }

    public int Precio { get; set; }

    public int valor { get; set; }
 }