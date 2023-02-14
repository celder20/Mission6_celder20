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
        public DbSet<ApplicationResponse> Responses { get; set; }

        //Seeding the database with a few movies
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<ApplicationResponse>().HasData(
                new ApplicationResponse
                {
                    AppId = 2,
                    Category = "Musical",
                    Title = "High School Musical",
                    Year = 2006,
                    Director = "Kenny Ortega",
                    Rating = "PG"
                },
                new ApplicationResponse
                {
                    AppId = 3,
                    Category = "Sports",
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
                    Category = "Suspense/Drama",
                    Title = "Interstellar",
                    Year = 2014,
                    Director = "Christopher Nolan",
                    Rating = "PG-13"
                }
                );
        }
    }
}
