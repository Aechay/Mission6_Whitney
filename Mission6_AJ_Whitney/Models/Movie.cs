using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6_AJ_Whitney.Models;

public class Movie
{
    [Key]
    [Required]
    public int MovieId { get; set; }
    [ForeignKey("CategoryId")]
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    [Required]
    public string Title { get; set; }

    [Required]
    [Range(1888, 2030, ErrorMessage = "Please enter a valid year between 1888 and 2030.")]
    public int Year { get; set; } = 2000;
    [Required]
    public string? Director { get; set; }
    [Required]
    public string? Rating { get; set; }
    public bool Edited { get; set; }
    public string? LentTo { get; set; }
    public bool CopiedToPlex { get; set; }
    [StringLength(25)]
    public string? Notes { get; set; }
}