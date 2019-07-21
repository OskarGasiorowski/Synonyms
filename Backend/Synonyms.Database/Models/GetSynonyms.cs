using System.Collections.Generic;

namespace Synonyms.Database.Models
{
    public class GetSynonyms
    {
        public int Id { get; set; }
        public string Term { get; set; }
        public IReadOnlyList<string> Synonyms { get; set; }
    }
}