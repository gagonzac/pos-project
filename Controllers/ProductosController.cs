using Microsoft.AspNetCore.Mvc;
using PosTestApi.Data;
using PosTestApi.Models;

namespace PosTestApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductosController : ControllerBase
{
    private readonly AppDbContext _db;

    public ProductosController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_db.Productos.ToList());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Producto producto)
    {
        _db.Productos.Add(producto);
        _db.SaveChanges();

        return Ok(producto);
    }
}