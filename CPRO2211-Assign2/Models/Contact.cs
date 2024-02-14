using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Contact
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    [Phone]
    public string Phone { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    // Optional Organization Field
    public string Organization { get; set; }

    // Foreign Key Relationship
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Please select a valid category")]
    public int CategoryId { get; set; }

    public Category Category { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime DateAdded { get; set; } = DateTime.UtcNow;

    // Read-only property to create a URL-friendly slug
    public string Slug => $"{FirstName}-{LastName}".ToLower().Replace(" ", "-");

    // Additional properties or methods can be added here
}
