using GBCSporting2021_Mac_and_Cheese;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting2021_Mac_and_Cheese.Models
{
    public class SportContext:DbContext
    {
        public SportContext(DbContextOptions<SportContext> options) : base(options)
        {

        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Technician> Technicians { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
                new Country { CountryId = 1, CountryName = "Canada"},
                new Country { CountryId = 2, CountryName = "USA"},
                new Country { CountryId = 3, CountryName = "India"},
                new Country { CountryId = 4, CountryName = "Australia"}
                );
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    CustId = 1,
                    CustFName = "Kaitlyn",
                    CustLName = "Anthoni",
                    Address = "123 Queen Street",
                    City = "Toronto",
                    State = "Ontario",
                    CountryId = 1,
                    PostalCode = "M8N 6V5",
                    CustEmail = "kanthoni@pge.com",
                    CustPhone = "647-123-4567"
                },
                new Customer
                {
                    CustId = 2,
                    CustFName = "Ania",
                    CustLName = "Irvin",
                    Address = "27 Ganesh st.",
                    City = "Mumbai",
                    State = "Maharashtra",
                    CountryId = 3,
                    PostalCode = "675 453",
                    CustEmail = "ania@mma.nidc.com",
                    CustPhone = "998-765-1432"
                },
                new Customer
                {
                    CustId = 3,
                    CustFName = "Gonzalo",
                    CustLName = "Keeton",
                    Address = "20 Central Perk",
                    City = "New York",
                    State = "New York",
                    CountryId = 2,
                    PostalCode = "Y6R 4T8",
                    CustEmail = "gonton@rft.com",
                    CustPhone = "256-432-5674"
                },
                new Customer
                {
                    CustId = 4,
                    CustFName = "Jeffery",
                    CustLName = "Malone",
                    Address = "445 West Village",
                    City = "Sydney",
                    State = "Sydney",
                    CountryId = 4,
                    PostalCode = "432 678",
                    CustEmail = "jeffmalone@psl.com",
                    CustPhone = "343-089-0076"
                }
                );
            modelBuilder.Entity<Product>().HasData(
                new Product 
                {
                    ProductId = 1,
                    Code = "TRNY10",
                    ProductName = "Tournament Master 1.0",
                    Price = 4.99,
                    DateReleased = DateTime.Parse("12/1/2015")
                },
                new Product
                {
                    ProductId = 2,
                    Code = "LEAG10",
                    ProductName = "League Scheduler 1.0",
                    Price = 4.99,
                    DateReleased = DateTime.Parse("5/1/2016")
                },
                new Product
                {
                    ProductId = 3,
                    Code = "LEAGD10",
                    ProductName = "League Scheduler Deluxe 1.0",
                    Price = 7.99,
                    DateReleased = DateTime.Parse("8/1/2016")
                },
                new Product
                {
                    ProductId = 4,
                    Code = "DRAFT10",
                    ProductName = "Draft Manager 1.0",
                    Price = 4.99,
                    DateReleased = DateTime.Parse("2/1/2017")
                },
                new Product
                {
                    ProductId = 5,
                    Code = "TEAM10",
                    ProductName = "Team Manager 1.0",
                    Price = 4.99,
                    DateReleased = DateTime.Parse("5/1/2017")
                }
                );
            modelBuilder.Entity<Technician>().HasData(
                new Technician
                {
                    TechId = 1,
                    TechName = "Alison Diaz",
                    TechEmail = "alison@sportsprosoftware.com",
                    TechPhone = "800-555-0443"
                },
                new Technician
                {
                    TechId = 2,
                    TechName = "Andrew Wilson",
                    TechEmail = "awilson@sportsprosoftware.com",
                    TechPhone = "800-555-0449"
                },
                new Technician
                {
                    TechId = 3,
                    TechName = "Gina Fiori",
                    TechEmail = "gfiori@sportsprosoftware.com",
                    TechPhone = "800-555-0459"
                },
                new Technician
                {
                    TechId = 4,
                    TechName = "Jason Lee",
                    TechEmail = "jason@sportsprosoftware.com",
                    TechPhone = "800-555-0444"
                }
                );
            modelBuilder.Entity<Incident>().HasData(
                new Incident
                {
                    IncidentId = 1,
                    CustomerId = 2,
                    ProductId = 4,
                    Title = "Could not install",
                    Description = "Could npt install the Draft Manager 1.0",
                    DateOpened = DateTime.Parse("1/8/2020"),
                    TechnicianId = 1
                },
                new Incident
                {
                    IncidentId = 2,
                    CustomerId = 1,
                    ProductId = 5,
                    Title = "Could not install",
                    Description = "Could npt install the Team Manager 1.0",
                    DateOpened = DateTime.Parse("1/8/2020")
                }
                ) ;
        }
    }
}
