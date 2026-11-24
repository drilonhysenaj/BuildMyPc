using BuildMyPcApi.Models.Dtos.Products;
using BuildMyPcApi.Services.Product;
using Microsoft.AspNetCore.Mvc;

namespace BuildMyPcApi.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController(IProductService productService) : ControllerBase
{
    /// <summary>
    /// Kthen krejt produktet aktive të katalogut, të renditura sipas emrit.
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await productService.GetAllAsync();
        return Ok(products);
    }

    /// <summary>
    /// Kthen një produkt sipas Id-së.
    /// </summary>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await productService.GetByIdAsync(id);
        if (product == null) return NotFound();
        return Ok(product);
    }

    /// <summary>
    /// Shton një produkt të ri.
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProductRequestDto dto)
    {
        var created = await productService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    /// <summary>
    /// Ndryshon një produkt ekzistues.
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ProductRequestDto dto)
    {
        var updated = await productService.UpdateAsync(id, dto);
        if (updated == null) return NotFound();
        return Ok(updated);
    }

    /// <summary>
    /// Çaktivizon një produkt. Produkti s'fshihet nga databaza.
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Deactivate(int id)
    {
        var deactivated = await productService.DeactivateAsync(id);
        if (!deactivated) return NotFound();
        return NoContent();
    }
}
