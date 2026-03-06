namespace PolyglotPlatform.Domain
{
    public class Level
    {
        public int LevelId { get; set; }
        public string LevelName { get; set; } = default!;
        public int LevelOrder { get; set; }

        public ICollection<Course> Courses { get; } = []; // Navigation property
    }
}
