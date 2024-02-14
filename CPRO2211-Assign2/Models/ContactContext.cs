using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

public class ContactContext : DbContext
{
    public ContactContext(DbContextOptions<ContactContext> options) : base(options)
    {
    }

    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed data for the Category table
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Family" },
            new Category { Id = 2, Name = "Friends" },
            new Category { Id = 3, Name = "Work" }
        );

        // Seed data for the Contact table
        _ = modelBuilder.Entity<Contact>().HasData(
            new Contact
            {
                Id = 1,
                FirstName = "Bergen",
                LastName = "Cunningham",
                Phone = "587-876-7305",
                Email = "bergcu2001@gmail.com",
                Organization = "Red Deer Polytechnic",
                CategoryId = 1,
                DateAdded = DateTime.Now
            },
            new Contact
            {
                Id = 2,
                FirstName = "Jeannelle",
                LastName = "Cousineau",
                Phone = "403-307-6227",
                Email = "jeannellecousineau2001@gmail.com",
                Organization = "Royal LePage",
                CategoryId = 2,
                DateAdded = DateTime.Now
            },
            new Contact
            {
                Id = 3,
                FirstName = "Steve",
                LastName = "Smith",
                Phone = "555-555-5555",
                Email = "steve.smith@gmail.com",
                Organization = null,
                CategoryId = 3,
                DateAdded = DateTime.Now
            }
        );

    }
}
