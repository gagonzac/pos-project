using Microsoft.AspNetCore.Mvc;
using PosTestApi.Data;

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
}