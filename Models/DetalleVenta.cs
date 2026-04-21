using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class DetalleVenta
{
    public int Id { get; set; } // OK (EF lo ignora al insertar)

    public int VentaId { get; set; }
    public int ProductoId { get; set; }

    public decimal Cantidad { get; set; }
    public decimal Subtotal { get; set; }
}