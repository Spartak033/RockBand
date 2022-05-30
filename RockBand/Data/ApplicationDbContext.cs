using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RockBand.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RockBand.Data
{
    public class AppUser : IdentityUser
    {
        [StringLength(30)]
        public string FirstName {get;set;}
        [StringLength(30)]
        public string LastName {get;set;}
        [ForeignKey("UserId")]
        public virtual ICollection<Sugestions> Sugestion { get; set; }
    }
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<AlbumSingle> AlbumSingle { get; set; }
        public DbSet<Concert> Concert { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Sugestions> Sugestions { get; set; }
    }
}
