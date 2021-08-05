using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Forum_v1.Models
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
