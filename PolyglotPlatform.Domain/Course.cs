namespace PolyglotPlatform.Domain
{
    public class Course
    {
        public int CourseId { get; set; }
        public string NativeCourseTitle { get; set; } = default!;
        public string EnglishCourseTitle { get; set; } = default!;
        public string PolishCourseTitle { get; set; } = default!;
        public int SortOrder { get; set; }

        public int LanguageId { get; set; } // Foreign Key
        public Language Language { get; set; } = default!; // Navigation property

        public int LevelId { get; set; } // Foreign Key
        public Level Level { get; set; } = default!; // Navigation property

        public ICollection<Chapter> Chapters { get; } = []; // Navigation property
    }
}
