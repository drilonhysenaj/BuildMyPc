using BuildMyPcApi.Database;
using BuildMyPcApi.Models.Dtos.Products;
using Microsoft.EntityFrameworkCore;
using ProductEntity = BuildMyPcApi.Models.Entities.Product;

namespace BuildMyPcApi.Services.Product;

public class ProductService : IProductService
{
    private readonly BuildMyPcDbContext _db;

    public ProductService(BuildMyPcDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<ProductResponseDto>> GetAllAsync()
    {
        return await _db.Products
            .Where(p => p.IsActive)
            .OrderBy(p => p.Name)
            .Select(p => ToResponseDto(p))
            .ToListAsync();
    }

    public async Task<ProductResponseDto?> GetByIdAsync(int id)
    {
        var product = await _db.Products.FindAsync(id);
        if (product == null) return null;

        return ToResponseDto(product);
    }

    public async Task<ProductResponseDto> CreateAsync(ProductRequestDto dto)
    {
        var product = new ProductEntity
        {
            Name = dto.Name,
            Brand = dto.Brand,
            Category = dto.Category,
            Price = dto.Price,
            Stock = dto.Stock,
            ImageUrl = dto.ImageUrl,
            IsActive = dto.IsActive
        };

        _db.Products.Add(product);
        await _db.SaveChangesAsync();

        return ToResponseDto(product);
    }

    public async Task<ProductResponseDto?> UpdateAsync(int id, ProductRequestDto dto)
    {
        var product = await _db.Products.FindAsync(id);
        if (product == null) return null;

        product.Name = dto.Name;
        product.Brand = dto.Brand;
        product.Category = dto.Category;
        product.Price = dto.Price;
        product.Stock = dto.Stock;
        product.ImageUrl = dto.ImageUrl;
        product.IsActive = dto.IsActive;

        await _db.SaveChangesAsync();

        return ToResponseDto(product);
    }

    public async Task<bool> DeactivateAsync(int id)
    {
        var product = await _db.Products.FindAsync(id);
        if (product == null) return false;

        product.IsActive = false;
        await _db.SaveChangesAsync();

        return true;
    }

    private static ProductResponseDto ToResponseDto(ProductEntity product)
    {
        return new ProductResponseDto
        {
            Id = product.Id,
            Name = product.Name,
            Brand = product.Brand,
            Category = product.Category,
            Price = product.Price,
            Stock = product.Stock,
            ImageUrl = product.ImageUrl,
            IsActive = product.IsActive,
            CreatedAt = product.CreatedAt
        };
    }
}