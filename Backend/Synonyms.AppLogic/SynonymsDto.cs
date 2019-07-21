using System.Collections.Generic;

namespace Synonyms.AppLogic
{
    public class SynonymsDto
    {
        public string Term { get; set; }
        public IReadOnlyList<string> Synonyms { get; set; }
    }
}