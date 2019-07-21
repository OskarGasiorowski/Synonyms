using System.Collections.Generic;
using System.Linq;
using Synonyms.Database.Models;

namespace Synonyms.AppLogic
{
    public static class AggregateSynonymsHelper
    {
        public static IReadOnlyList<SynonymsDto> AggregateSynonyms(this IReadOnlyList<SynonymsDto> synonyms)
        {
            var defaultSyn = synonyms.SynonymsGroup()
                .ToList();
            
            var reversSyn = defaultSyn
                .Select(syn => syn.Synonyms
                    .Select(synTo => new SynonymsDto
                    {
                        Term = synTo,
                        Synonyms = new []{syn.Term}
                    })
                ).SelectMany(syn => syn)
                .SynonymsGroup()
                .ToList();

            return defaultSyn.Union(reversSyn)
                .SynonymsGroup()
                .ToList();
        }

        private static IEnumerable<SynonymsDto> SynonymsGroup(this IEnumerable<SynonymsDto> data)
            => data.GroupBy(syn => syn.Term)
                .Select(groupedSyn => new SynonymsDto
                {
                    Term = groupedSyn.Key,
                    Synonyms = groupedSyn
                        .Select(syn => syn.Synonyms)
                        .SelectMany(syn => syn)
                        .Distinct()
                        .ToList()
                });
    }
}