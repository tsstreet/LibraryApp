using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Data.Model
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<ClassStudent>()
        //        .HasKey(cs => new { cs.ClassId, cs.StudentId });

        //    foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        //    {
        //        relationship.DeleteBehavior = DeleteBehavior.Restrict;
        //    }
        //}

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }    

        public DbSet<User> Users { get; set; }
        public DbSet<Subject> Subjects { get; set; }

    }
}
