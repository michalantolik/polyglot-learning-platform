namespace PolyglotPlatform.Domain
{
    public class Language
    {
        public int LanguageId { get; set; }
        public string LanguageCode { get; set; } = default!;
        public string NativeLanguageName { get; set; } = default!;
        public string EnglishLanguageName { get; set; } = default!;
        public string PolishLanguageName { get; set; } = default!;

        public ICollection<Course> Courses { get; } = []; // Navigation property
    }
}
