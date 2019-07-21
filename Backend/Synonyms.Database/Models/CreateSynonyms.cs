using System.Collections.Generic;

namespace Synonyms.Database.Models
{
    public class CreateSynonyms
    {
        public string Term { get; set; }
        public IReadOnlyList<string> Synonyms { get; set; }
    }
}