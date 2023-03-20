using System.ComponentModel.DataAnnotations;

 namespace  CellSystem.Shared.Requests;
public class ClienteCreateRequest{

             
        public string Nombre {get; set;}= null!;
        public int cedula{get; set;} 
        public int Telefono {get; set;}       
}
