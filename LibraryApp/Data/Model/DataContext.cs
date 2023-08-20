using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Data.Model
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClassStudent>()
                .HasKey(cs => new { cs.ClassId, cs.StudentId });

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }    

        public DbSet<User> Users { get; set; }

        public DbSet<ClassStudent> ClassStudents { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<AcademicYear> AcademicYears { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Department> Departments { get; set; }

        public DbSet<Falcuty> Falcuties { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        public DbSet<GradeType> GradeTypes { get; set; }
        public DbSet<OffSchedule> OffSchedules { get; set; }

        public DbSet<SubjectGrade> SubjectGrades { get; set; }
    }
}
