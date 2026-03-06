namespace PolyglotPlatform.Domain
{
    public class Chapter
    {
        public int ChapterId { get; set; }
        public string NativeChapterTitle { get; set; } = default!;
        public string EnglishChapterTitle { get; set; } = default!;
        public string PolishChapterTitle { get; set; } = default!;
        public int SortOrder { get; set; }

        public int CourseId { get; set; } // Foreign Key
        public Course Course { get; set; } = default!; // Navigation property

        public ICollection<Exercise> Exercises { get; } = []; // Navigation property
    }
}
