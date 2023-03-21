<<<<<<< HEAD
=======

>>>>>>> e911a4eed99da54e3f554133a286af06d1bf5d3e
using System.ComponentModel.DataAnnotations;

namespace CellSystem.Shared.Requests;

public class ClienteCreateRequest
{   
        [Required (ErrorMessage="Proporcione un Nombre")]
        public string Nombre {get; set;}= null!;
<<<<<<< HEAD
        public int cedula{get; set;} 
        public int Telefono {get; set;}  
}
=======

        public int cedula{get; set;} 

        public int Telefono {get; set;}  
}
 
>>>>>>> e911a4eed99da54e3f554133a286af06d1bf5d3e
