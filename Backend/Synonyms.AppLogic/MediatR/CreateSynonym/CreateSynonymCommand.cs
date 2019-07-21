using System.Collections.Generic;
using MediatR;

namespace Synonyms.AppLogic.MediatR.CreateSynonym
{
    public class CreateSynonymCommand : IRequest
    {
        public string Term { get; set; }
        public IReadOnlyList<string> Synonyms { get; set; }
    }
}