using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Mapster;
using MediatR;
using Synonyms.Database;

namespace Synonyms.AppLogic.MediatR.GetSynonyms
{
    public class GetSynonymsHandler : IRequestHandler<GetSynonymsCommand, IReadOnlyList<SynonymsDto>>
    {
        private readonly ISynonymsRepository synonymsRepository;

        public GetSynonymsHandler(ISynonymsRepository synonymsRepository)
        {
            this.synonymsRepository = synonymsRepository;
        }

        public async Task<IReadOnlyList<SynonymsDto>> Handle(GetSynonymsCommand request, CancellationToken cancellationToken)
        {
            return (await this.synonymsRepository.Get())
                .Adapt<IReadOnlyList<SynonymsDto>>()
                .AggregateSynonyms();
        }
    }
}