namespace CellSystem.Shared.Records;

public class FacturarRecord{
    public FacturarRecord(string pago, int total, int descuento)
    {
        this.Pago = pago;
        this.Total = total;
        this.Descuento = descuento;
    }

    public string Pago { get; set; }=null!;
    public int Total { get; set; }
    public int Descuento { get; set; }

}