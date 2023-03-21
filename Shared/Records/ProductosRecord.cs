
namespace CellSystem.Shared.Records;

public class ProductosRecord
{
    public ProductosRecord()
    {
    }

    public ProductosRecord(string nombre, string modelo, string marca, string tipo, int cantidad, int precio, int valor)
    {
        this.Nombre = nombre;
        this.Modelo = modelo;
        this.Marca = marca;
        this.Tipo = tipo;
        this.Cantidad = cantidad;
        this.Precio = precio;
        this.valor = valor;
    }

    public string Nombre{get; set;}= null!;
    public string Modelo { get; set; }= null!;

    public string Marca { get; set; } = null!;

    public string Tipo { get; set; }= null!;

    public int Cantidad{ get; set; }

    public int Precio { get; set; }

    public int valor { get; set; }
}