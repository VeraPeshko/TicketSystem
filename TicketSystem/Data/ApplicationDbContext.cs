using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using TicketSystem.Models;

namespace TicketSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<Passenger>
    {
        public DbSet<Train> Trains { get; set; }
        public DbSet<Journey> Journeys { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Journey>()
            .HasOne(j => j.Train)
            .WithMany()
            .HasForeignKey(j => j.TrainId);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Journey)
                .WithMany()
                .HasForeignKey(t => t.JourneyId);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Passenger)
                .WithMany()
                .HasForeignKey(t => t.PassengerId);

        }
    }
}
