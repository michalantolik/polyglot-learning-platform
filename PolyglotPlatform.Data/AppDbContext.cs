using Microsoft.EntityFrameworkCore;
using PolyglotPlatform.Domain;

namespace PolyglotPlatform.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Language> Languages => Set<Language>();
        public DbSet<Level> Levels => Set<Level>();
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<Chapter> Chapters => Set<Chapter>();
        public DbSet<Exercise> Exercises => Set<Exercise>();
        public DbSet<ExerciseType> ExerciseTypes => Set<ExerciseType>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // -------------------------
            // Language
            // -------------------------
            modelBuilder.Entity<Language>(e =>
            {
                e.HasKey(x => x.LanguageId);

                e.Property(x => x.LanguageCode).IsRequired().HasMaxLength(10);
                e.Property(x => x.NativeLanguageName).IsRequired().HasMaxLength(100);
                e.Property(x => x.EnglishLanguageName).IsRequired().HasMaxLength(100);
                e.Property(x => x.PolishLanguageName).IsRequired().HasMaxLength(100);

                e.HasIndex(x => x.LanguageCode).IsUnique();

                e.HasMany(x => x.Courses)
                 .WithOne(x => x.Language)
                 .HasForeignKey(x => x.LanguageId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            // -------------------------
            // Level
            // -------------------------
            modelBuilder.Entity<Level>(e =>
            {
                e.HasKey(x => x.LevelId);

                e.Property(x => x.LevelName).IsRequired().HasMaxLength(20);
                e.Property(x => x.LevelOrder).IsRequired();

                e.HasIndex(x => x.LevelOrder).IsUnique();

                e.HasMany(x => x.Courses)
                 .WithOne(x => x.Level)
                 .HasForeignKey(x => x.LevelId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            // -------------------------
            // Course
            // -------------------------
            modelBuilder.Entity<Course>(e =>
            {
                e.HasKey(x => x.CourseId);

                e.Property(x => x.NativeCourseTitle).IsRequired().HasMaxLength(200);
                e.Property(x => x.EnglishCourseTitle).IsRequired().HasMaxLength(200);
                e.Property(x => x.PolishCourseTitle).IsRequired().HasMaxLength(200);

                e.Property(x => x.SortOrder).IsRequired();

                // Unique order within (Language, Level)
                e.HasIndex(x => new { x.LanguageId, x.LevelId, x.SortOrder }).IsUnique();

                e.HasMany(x => x.Chapters)
                 .WithOne(x => x.Course)
                 .HasForeignKey(x => x.CourseId)
                 .OnDelete(DeleteBehavior.Cascade);
            });

            // -------------------------
            // Chapter
            // -------------------------
            modelBuilder.Entity<Chapter>(e =>
            {
                e.HasKey(x => x.ChapterId);

                e.Property(x => x.NativeChapterTitle).IsRequired().HasMaxLength(200);
                e.Property(x => x.EnglishChapterTitle).IsRequired().HasMaxLength(200);
                e.Property(x => x.PolishChapterTitle).IsRequired().HasMaxLength(200);

                e.Property(x => x.SortOrder).IsRequired();

                // Unique order within a course
                e.HasIndex(x => new { x.CourseId, x.SortOrder }).IsUnique();

                e.HasMany(x => x.Exercises)
                 .WithOne(x => x.Chapter)
                 .HasForeignKey(x => x.ChapterId)
                 .OnDelete(DeleteBehavior.Cascade);
            });

            // -------------------------
            // ExerciseType
            // -------------------------
            modelBuilder.Entity<ExerciseType>(e =>
            {
                e.HasKey(x => x.ExerciseTypeId);

                e.Property(x => x.ExerciseTypeName).IsRequired().HasMaxLength(50);
                e.HasIndex(x => x.ExerciseTypeName).IsUnique();

                e.HasMany(x => x.Exercises)
                 .WithOne(x => x.ExerciseType)
                 .HasForeignKey(x => x.ExerciseTypeId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            // -------------------------
            // Exercise
            // -------------------------
            modelBuilder.Entity<Exercise>(e =>
            {
                e.HasKey(x => x.ExerciseId);

                e.Property(x => x.EnglishPrompt).IsRequired().HasMaxLength(500);
                e.Property(x => x.PolishPrompt).IsRequired().HasMaxLength(500);
                e.Property(x => x.Answer).IsRequired().HasMaxLength(500);

                e.Property(x => x.SortOrder).IsRequired();

                // Unique order within a chapter
                e.HasIndex(x => new { x.ChapterId, x.SortOrder }).IsUnique();
            });
        }
    }
}
