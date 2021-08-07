using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string ClientName { set; get; }
        public string CompanyName { set; get; }
        public DateTime DateOfRegistration { set; get; }
        public bool Ban { set; get; }

        public ApplicationUser()
        {
            DateOfRegistration = DateTime.Now;
            Ban = false;
        }
    }



    public class BanEmail
    {
        public int Id { set; get; }
        public string Email { set; get; }

    }



    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<BanEmail> BanEmails { set; get; }



        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //Database.EnsureCreated();  
        }

    }
}
