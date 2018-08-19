using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VacationFormPractice.Models;

namespace VacationFormPractice.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<TravelerProfile> travelerProfiles { get; set; } //NOTE: This will be the name of our table. Also, this table name will be used in TravelerProfiles later on when we do our Linq queries (e.g. when we add new data in the CREATE method).       

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            var tolist = VacationCategory.Include("VacationPlaces").ToList();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {            
            base.OnModelCreating(builder);            
        }

        public DbSet<VacationFormPractice.Models.VacationPlaces> VacationPlaces { get; set; }

        public DbSet<VacationFormPractice.Models.VacationCategory> VacationCategory { get; set; }
    }
}
