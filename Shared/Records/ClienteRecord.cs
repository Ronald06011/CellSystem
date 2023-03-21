
namespace CellSystem.Shared.Records;

public class ClienteRecord{
    public ClienteRecord()
    {
    }

    public ClienteRecord(string nombre , int cedula, int telefono )
    {
        this.Nombre = nombre;
        this.cedula = cedula;
        this.Telefono = telefono;
    }

         public string Nombre {get; set;}= null!;

        public int cedula{get; set;} 

        public int Telefono {get; set;}

}