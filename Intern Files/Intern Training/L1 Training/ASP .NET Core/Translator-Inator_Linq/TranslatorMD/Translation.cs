using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslatorMD
{
    public class Translation
    {
        [Key]
        public int TranslationId { get; set; }

        public string TranslationString { get; set; }

        public string FromLang { get; set; }

        public string ToLang { get; set; }
    }
}
