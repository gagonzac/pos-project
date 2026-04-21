using Microsoft.AspNetCore.Mvc;
using PosTestApi.Data;
using PosTestApi.Models;

namespace PosTestApi.Controllers;

[ApiController]
[Route("[controller]")]
public class VentasController : ControllerBase
{
    private readonly AppDbContext _db;

    public VentasController(AppDbContext db)
    {
        _db = db;
    }

    [HttpPost]
    public IActionResult Post([FromBody] Venta venta)
    {
        var existe = _db.Ventas.Any(v => v.Uuid == venta.Uuid);

        if (existe)
            return Ok("Duplicado");

        // EF guardará venta + detalles automáticamente
        _db.Ventas.Add(venta);
        _db.SaveChanges();

        return Ok("Guardado completo");
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_db.Ventas.ToList());
    }
}