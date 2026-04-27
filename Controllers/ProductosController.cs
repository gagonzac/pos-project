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

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Producto producto)
    {
        var existente = _db.Productos.Find(id);
        if (existente == null) return NotFound();

        existente.Nombre = producto.Nombre;
        existente.Precio = producto.Precio;
        existente.Tipo = producto.Tipo;

        _db.SaveChanges();
        return Ok(existente);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var producto = _db.Productos.Find(id);
        if (producto == null) return NotFound();

        _db.Productos.Remove(producto);
        _db.SaveChanges();

        return Ok();
    }

}