using System.ComponentModel.DataAnnotations;
using System.Runtime.Versioning;
using BuildMyPcApi.Models.Enums;

namespace BuildMyPcApi.Models.Entities;

public class Product
{
    [Key]
    public int Id {get; set;}

    [Required]
    [MaxLength(200)]
    public string Name {get;  set;} = string.Empty;

    [Required]
    [MaxLenght(100)]
    public string Brand {get; set;} = string.Empty;

    [Required]
    public PartCategory Category{get; set;}

    [Required]
    public decimal Price{get; set;}
    [Required]
    public int Stock {get; set;}

    [MaxLength(500)]
    public string? ImageUrl{get; set;} 

    public bool IsActive{ get; set;} = true;
    public DateTime  CreatedAt {get; set;} = DateTime.UtcNow;
}