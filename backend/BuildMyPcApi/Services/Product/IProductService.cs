using BuildMyPcApi.Models.Dtos.Products;

namespace BuildMyPcApi.Services.Product;

public interface IProductService
{
    Task<IEnumerable<ProductResponseDto>> GetAllAsync();
    Task<ProductResponseDto?> GetByIdAsync(int id);
    Task<ProductResponseDto> CreateAsync(ProductRequestDto dto);
    Task<ProductResponseDto?> UpdateAsync(int id, ProductRequestDto dto);
    Task<bool> DeactivateAsync(int id);
}