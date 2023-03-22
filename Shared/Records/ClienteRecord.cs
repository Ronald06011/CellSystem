
namespace CellSystem.Shared.Records;

public class ClienteRecord{
    public ClienteRecord()
    {
    }

    public ClienteRecord(int id,string nombre , int cedula, int telefono )
    {
        this.Id = id;
        this.Nombre = nombre;
        this.cedula = cedula;
        this.Telefono = telefono;
    }
     public int Id { get; set; }

    public string Nombre {get; set;}= null!;

    public int cedula{get; set;} 

     public int Telefono {get; set;}

}