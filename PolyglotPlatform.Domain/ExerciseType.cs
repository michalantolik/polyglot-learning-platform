namespace PolyglotPlatform.Domain
{
    public class ExerciseType
    {
        public int ExerciseTypeId { get; set; }
        public string ExerciseTypeName { get; set; } = default!;

        public ICollection<Exercise> Exercises { get; } = []; // Navigation property
    }
}
