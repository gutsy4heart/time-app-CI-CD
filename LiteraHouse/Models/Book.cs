﻿using System.ComponentModel.DataAnnotations;

namespace LiteraHouse.Models;

public class Book
{
    [Key]
    public int Id { get; set; }
    [Required]
    [RegularExpression("^[a-zA-Z0-30]*$", ErrorMessage = "Only letters and numbers are allowed.")]
    public string Title { get; set; } = string.Empty;
    [Required]
    public string Description { get; set; } = string.Empty;
    [Required]
    public string Author { get; set; } = string.Empty;
    [Required]
    public string Genre { get; set; } = string.Empty;
    [Required]
    public string Publishing { get; set; } = string.Empty;
    [Required]
    public string Created { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    [Required]
    public decimal Price { get; set; }


}

