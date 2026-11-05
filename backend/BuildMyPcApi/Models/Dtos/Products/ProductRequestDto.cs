using System.ComponentModel.DataAnnotations;
using BuildMyPcApi.Models.Enums;

namespace BuildMyPcApi.Models.Dtos.Products;

public class ProductRequestDto
{
    [Required]
    [StringLength(200)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string Brand { get; set; } = string.Empty;

    [EnumDataType(typeof(PartCategory))]
    public PartCategory Category { get; set; }

    [Range(0.01, 100000)]
    public decimal Price { get; set; }

    [Range(0, 100000)]
    public int Stock { get; set; }

    [StringLength(500)]
    [Url]
    public string? ImageUrl { get; set; }

    public bool IsActive { get; set; } = true;
}