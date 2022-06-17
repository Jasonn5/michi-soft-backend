using Authentication.DataAccess.Context;
using DataAccess.Model;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public class MichiSystemContext : AuthContext
    {
        public MichiSystemContext(DbContextOptions<MichiSystemContext> options) : base(options)
        {
        }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Matter> Matters { get; set; }
        public DbSet<ClassRoom> ClassRooms { get; set; }
        public DbSet<ClassroomSchedule> ClassroomSchedules { get; set; }
        public DbSet<Customize> Customizes { get; set; }

        // CUSTOM
        public virtual DbSet<BookingDetail> BookingDetails { get; set; }
        public virtual DbSet<MattersByProfessor> MattersByProfessor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
