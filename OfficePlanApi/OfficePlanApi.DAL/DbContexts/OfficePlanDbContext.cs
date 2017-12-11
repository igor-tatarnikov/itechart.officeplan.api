using Microsoft.EntityFrameworkCore;
using OfficePlanApi.Domain.Entities;

namespace OfficePlanApi.DAL.DbContexts
{
    public class OfficePlanDbContext : DbContext
    {
        public OfficePlanDbContext(DbContextOptions<OfficePlanDbContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Furniture> Furniture { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomObject> RoomObjects { get; set; }
        public DbSet<Workplace> Workplaces { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
