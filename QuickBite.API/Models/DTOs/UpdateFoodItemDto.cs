using QuickBite.API.Models.Enums;

namespace QuickBite.API.Models.DTOs;

public class UpdateFoodItemDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal? Price { get; set; }
    public FoodCategory? Category { get; set; }
    public DietaryTag? DietaryTag { get; set; }
}