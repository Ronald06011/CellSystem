using System.ComponentModel.DataAnnotations;

namespace CellSystem.Shared.Requests;

public class ClienteCreateRequest
{   
        public int Id { get; set; }
        [Required (ErrorMessage="Proporcione un Nombre")]

        public string Nombre {get; set;}= null!;
        [Required(ErrorMessage ="Debe Escribir una cedula"+"40213790617")]
        public int cedula{get; set;} 
        public int Telefono {get; set;}  
}
