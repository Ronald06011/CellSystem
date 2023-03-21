using System.Net.Cache;
using CellSystem.Shared.Requests;
using CellSystem.Shared.Records;
using System.ComponentModel.DataAnnotations;

namespace CellSystem.Server.Models;

public class Cliente
{
           [Key]
        public string Nombre {get; set;}= null!;
        public int Cedula{get; set;} 
        public int Telefono {get; set;}

}