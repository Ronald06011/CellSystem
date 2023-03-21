namespace CellSystem.Shared.Records;

public class FacturarRecord{
    public FacturarRecord(string pago, int total, int descuento)
    {
        this.pago = pago;
        this.Total = total;
        this.Descuento = descuento;
    }

    public string pago { get; set; }=null!;
    public int Total { get; set; }
    public int Descuento { get; set; }

}