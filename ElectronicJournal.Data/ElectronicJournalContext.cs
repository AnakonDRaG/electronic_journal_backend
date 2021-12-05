using ElectronicJournal.Domain;
using Microsoft.EntityFrameworkCore;

namespace ElectronicJournal.Data
{
    public class ElectronicJournalContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Journal> Journals { get; set; }
        public DbSet<SubjectInJournal> SubjectsInJournals { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<LessonScore> LessonScores { get; set; }
        public DbSet<Human> Humans { get; set; }
        public DbSet<User> Users { get; set; }

        public ElectronicJournalContext(DbContextOptions<ElectronicJournalContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>()
            .HasOne(c => c.ClassroomTeacher)
            .WithOne(t => t.CurrentClass)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Class>()
            .HasOne(c => c.Headman)
            .WithOne()
            .HasForeignKey<Class>(c => c.HeadmanId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Class>()
            .HasOne(c => c.CurrentJournal)
            .WithOne()
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Journal>()
            .HasOne(j => j.Class)
            .WithMany(c => c.Journals);

            modelBuilder.Entity<SubjectInJournal>()
           .HasOne(s => s.Teacher)
           .WithMany(t => t.SubjectsInJournal)
           .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Teacher>()
            .HasOne(t => t.CurrentClass)
            .WithOne(c => c.ClassroomTeacher)
            .HasForeignKey<Class>(c => c.ClassroomTeacherId);

            modelBuilder.Entity<Student>()
            .HasOne(s => s.Class)
            .WithMany(c => c.Students)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Human>()
            .HasOne(h => h.User)
            .WithOne(u => u.Human);

            modelBuilder.Entity<Class>()
                .Property(c => c.HeadmanId)
                .IsRequired(false);

            modelBuilder.Entity<Student>()
                .Property(c => c.ClassId)
                .IsRequired(false);

        }
    }
}