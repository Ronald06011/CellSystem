using System.ComponentModel.DataAnnotations;

namespace CellSystem.Server.Models;

public class Clientes
{
           [Key]
        public string Nombre {get; set;}= null!;
        public int cedula{get; set;} 
        public int Telefono {get; set;}
}