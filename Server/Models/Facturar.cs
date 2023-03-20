namespace   CellSystem.Server.Models;

public class facturar: Productos{
    public string pago { get; set; }=null!;
    public int Total { get; set; }
    public int Descuento { get; set; }

}