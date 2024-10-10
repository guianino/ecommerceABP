using System;
using System.ComponentModel.DataAnnotations;

namespace ecommerce.Products;

public class CreateUpdateProductDto
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Description { get; set; }

    [Required]
    public double Price { get; set; }

    [Required]
    public int Stock  { get; set; }
    
    [Required]
    public ProductCategory Category { get; set; }
}
