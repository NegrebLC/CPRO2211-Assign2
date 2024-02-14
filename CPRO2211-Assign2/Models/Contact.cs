using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Contact
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Please enter a first name!")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Please enter a last name!")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Please enter a valid phone number!")]
    [Phone(ErrorMessage = "Please enter a valid phone number!")]
    public string Phone { get; set; }

    [Required(ErrorMessage = "Please enter a valid email!")]
    [EmailAddress(ErrorMessage = "Please enter a valid email!")]
    public string Email { get; set; }

    // Optional Organization Field
    public string? Organization { get; set; } = string.Empty;

    // Foreign Key Relationship
    [Required(ErrorMessage = "Please enter a valid category!")]
    [Range(1, int.MaxValue, ErrorMessage = "Please select a valid category")]
    public int CategoryId { get; set; }

    public Category Category { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime DateAdded { get; set; } = DateTime.Now;

    // Read-only property to create a URL-friendly slug
    public string Slug => $"{FirstName}-{LastName}".ToLower().Replace(" ", "-");
}
