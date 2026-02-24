using System.ComponentModel.DataAnnotations;

namespace CP1.Architecture.ViewModels;

/// <summary>
/// ViewModel para mover datos de Foodbank entre Web y los backends.
/// </summary>
public class FoodbankViewModel
{
    public int FoodItemId { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    public string? Category { get; set; }
    public string? Brand { get; set; }
    public string? Description { get; set; }

    public decimal Price { get; set; }
    public string? Unit { get; set; }
    public int? QuantityInStock { get; set; }

    public DateTime? ExpirationDate { get; set; }

    public bool? IsPerishable { get; set; }
    public int? CaloriesPerServing { get; set; }
    public string? Ingredients { get; set; }
    public string? Barcode { get; set; }
    public string? Supplier { get; set; }
    public DateTime? DateAdded { get; set; }
    public bool? IsActive { get; set; }

    public int? RoleId { get; set; }
}
