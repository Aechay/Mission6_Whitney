namespace Mission6_AJ_Whitney.Models;
using System.ComponentModel.DataAnnotations;

public class Category
{
    [Key]
    [Required]
    public int CategoryId { get; set; }
    [Required]
    public string CategoryName { get; set; }
}