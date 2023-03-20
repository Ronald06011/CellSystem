using System.ComponentModel.DataAnnotations;

namespace CellSystem.Shared.Requests;

public class ClienteUpdateRequest
{   
        [Required (ErrorMessage="Proporcione un Nombre")]
        public string Nombre {get; set;}= null!;
        public int cedula{get; set;} 
        public int Telefono {get; set;}  
}
 public class ClienteCreateRequest: ClienteUpdateRequest
 {  
        [Required (ErrorMessage ="Debe Proporcionar un nombre")]
        public new string  Nombre { get; set; }=null!;
 }