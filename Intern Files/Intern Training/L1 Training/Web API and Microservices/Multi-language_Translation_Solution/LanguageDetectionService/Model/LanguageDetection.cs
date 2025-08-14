using System.ComponentModel.DataAnnotations;

namespace LanguageDetectionService.Model
{
    public class LanguageDetection
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Origin { get; set; }

        public string? Notes { get; set; }
    }
}
