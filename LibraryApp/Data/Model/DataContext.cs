using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Data.Model
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    modelBuilder.Entity<Subject>()
        //                .HasMany(s => s.Topics)
        //                .WithOne(t => t.Subject)
        //                .HasForeignKey(t => t.SubjectId)
        //                .OnDelete(DeleteBehavior.Cascade);

        //    modelBuilder.Entity<Topic>()
        //        .HasMany(t => t.Lectures)
        //        .WithOne()
        //        .HasForeignKey(l => l.TopicId)
        //        .OnDelete(DeleteBehavior.Cascade);
        //}

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }    

        public DbSet<User> Users { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Class> Classes { get; set; }

        public DbSet<Document> Documents { get; set; }

        public DbSet<Lecture> Lectures { get; set; }

        public DbSet<PrivateFile> PrivateFiles { get; set; }

        public DbSet<Exam> Exams { get; set; }

        public DbSet<Topic> Topics { get; set; }

    }
}
