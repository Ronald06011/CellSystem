using System.Net.Cache;
using CellSystem.Shared.Requests;
using CellSystem.Shared.Records;
using System.ComponentModel.DataAnnotations;
using CellSystem.Shared.Records;
using CellSystem.Shared.Requests;

namespace CellSystem.Server.Models;

public class Cliente
{
        [Key]
        public string Nombre {get; set;}= null!;
        public int Cedula{get; set;} 
        public int Telefono {get; set;}
<<<<<<< HEAD
        public static Cliente Crear (ClienteCreateRequest request)
        {
                return new Cliente(){
                        Nombre =  request.Nombre,
                        Cedula = request.cedula,
                        Telefono = request.Telefono

                };
        }
=======

>>>>>>> e911a4eed99da54e3f554133a286af06d1bf5d3e
}