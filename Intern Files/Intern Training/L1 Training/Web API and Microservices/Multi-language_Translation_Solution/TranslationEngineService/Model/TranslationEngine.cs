using System.ComponentModel.DataAnnotations;

namespace TranslationEngineService.Model
{
    public class TranslationEngine
    {
        [Key]
        public int Id { get; set; }

        public string TranslationString { get; set; }

        public string FromLang { get; set; }

        public string ToLang { get; set; }
    }
}
