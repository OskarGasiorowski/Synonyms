using System.Collections.Generic;
using MediatR;

namespace Synonyms.AppLogic.MediatR.GetSynonyms
{
    public class GetSynonymsCommand : IRequest<IReadOnlyList<SynonymsDto>> {}
}