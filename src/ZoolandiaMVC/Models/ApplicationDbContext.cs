using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using ZoolandiaMVC.Models;
using ZoolandiaMVC.ViewModels;

namespace ZoolandiaMVC.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        public DbSet<Animal> Animal { get; set; }
        public DbSet<Habitat> Habitat { get; set; }
        public DbSet<HabitatType> HabitatType { get; set; }
        public DbSet<Species> Species { get; set; }
        public DbSet<AnimalDataViewModel> AnimalDataViewModel { get; set; }
        public DbSet<Document> Document { get; set; }
    }
}
