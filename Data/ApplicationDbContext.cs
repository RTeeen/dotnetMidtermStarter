using dotnetMidtermStarter.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace dotnetMidtermStarter.Data
{
    public class ApplicationDbContext  : IdentityDbContext
    {

         public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //Add Your entity here after creating the Model

        public DbSet<Student>? Students { get; set; }



    }
}

