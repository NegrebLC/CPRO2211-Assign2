using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Category
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    // Navigation property to establish the one-to-many relationship
    public ICollection<Contact> Contacts { get; set; }
}