using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestAPIserver.Models;

namespace TestAPIserver.Models
{
    public class DBContext : DbContext
    {
        public DBContext (DbContextOptions<DBContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SurveyUser>()
                .HasKey(su => new { su.SurveyId, su.UserId });

            modelBuilder.Entity<SurveyUser>()
                .HasOne(su => su.Survey)
                .WithMany(p => p.SurveyUsers)
                .HasForeignKey(su => su.SurveyId);

            modelBuilder.Entity<SurveyUser>()
                .HasOne(su => su.User)
                .WithMany(c => c.SurveyUsers)
                .HasForeignKey(su => su.UserId);
        }


        public DbSet<Survey> Surveys { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<SurveyUser> SurveyUsers { get; set; }
    }
}
