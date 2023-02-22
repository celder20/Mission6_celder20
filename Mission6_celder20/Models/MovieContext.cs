using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6_celder20.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext (DbContextOptions<MovieContext> options) : base(options)
        {
            //Leave blank for now
        }
        //Make the Responses table
        public DbSet<ApplicationResponse> Responses { get; set; }
        //Making the categories table
        public DbSet<Category> Categories { get; set; }

        //Seeding the database with a few movies
        protected override void OnModelCreating(ModelBuilder mb)
        {
            //This is creating the category table in the database
            mb.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "Sports"
                },
                new Category
                {
                    CategoryId = 2,
                    CategoryName = "Suspense/Drama"
                },
                new Category
                {
                    CategoryId = 3,
                    CategoryName = "Action/Romance"
                },
                new Category
                {
                    CategoryId = 4,
                    CategoryName = "Musical"
                },
                new Category
                {
                    CategoryId = 5,
                    CategoryName = "Romance"
                },
                new Category
                {
                    CategoryId = 6,
                    CategoryName = "Romance-Comedy (Rom-Com)"
                },
                new Category
                {
                    CategoryId = 7,
                    CategoryName = "Horror"
                },
                new Category
                {
                    CategoryId = 8,
                    CategoryName = "Mystery"
                },
                new Category
                {
                    CategoryId = 9,
                    CategoryName = "Comedy"
                },
                new Category
                {
                    CategoryId = 10,
                    CategoryName = "Adventure"
                },
                new Category
                {
                    CategoryId = 11,
                    CategoryName = "Thriller"
                },
                new Category
                {
                    CategoryId = 12,
                    CategoryName = "Other"
                }
                );

            mb.Entity<ApplicationResponse>().HasData(
                new ApplicationResponse
                {
                    AppId = 2,
                    CategoryId = 4,
                    Title = "High School Musical",
                    Year = 2006,
                    Director = "Kenny Ortega",
                    Rating = "PG"
                },
                new ApplicationResponse
                {
                    AppId = 3,
                    CategoryId = 1,
                    Title = "Remember the Titans",
                    Year = 2000,
                    Director = "Boaz Yakin",
                    Rating = "PG",
                    Edited = false,
                    LentTo = "Jason Thompson",
                    Notes = "The best sports movie!"
                },
                new ApplicationResponse
                {
                    AppId = 4,
                    CategoryId = 2,
                    Title = "Interstellar",
                    Year = 2014,
                    Director = "Christopher Nolan",
                    Rating = "PG-13"
                }
                );
        }
    }
}
