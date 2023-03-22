using System.ComponentModel.DataAnnotations;
using CellSystem.Shared.Records;
using CellSystem.Shared.Requests;

namespace CellSystem.Server.Models;

public class Cliente
{
        [Key]
        public int Id { get; set; }
        public string Nombre {get; set;}= null!;
        public int Cedula{get; set;} 
        public int Telefono {get; set;}
        public static Cliente Crear (ClienteCreateRequest request)
        {
                return new Cliente(){
                        Nombre =  request.Nombre,
                        Cedula = request.cedula,
                        Telefono = request.Telefono

                };
        }
 public ClienteRecord ToRecord() 
    {
      return new ClienteRecord(Id,Nombre,Cedula,Telefono);
    }
  
}