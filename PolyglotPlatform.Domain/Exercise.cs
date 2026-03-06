namespace PolyglotPlatform.Domain
{
    public class Exercise
    {
        public int ExerciseId { get; set; }
        public string EnglishPrompt { get; set; } = default!;
        public string PolishPrompt { get; set; } = default!;
        public string Answer { get; set; } = default!;
        public int SortOrder { get; set; }

        public int ChapterId { get; set; } // Foreign Key
        public Chapter Chapter { get; set; } = default!; // Navigation property

        public int ExerciseTypeId { get; set; } // Foreign Key
        public ExerciseType ExerciseType { get; set; } = default!; // Navigation property
    }
}
