using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Mapster;
using MediatR;
using Synonyms.Database;
using Synonyms.Database.Models;

namespace Synonyms.AppLogic.MediatR.CreateSynonym
{
    public class CreateSynonymHandler : IRequestHandler<CreateSynonymCommand, Unit>
    {
        private readonly ISynonymsRepository synonymsRepository;

        public CreateSynonymHandler(ISynonymsRepository synonymsRepository)
        {
            this.synonymsRepository = synonymsRepository;
        }

        public async Task<Unit> Handle(CreateSynonymCommand request, CancellationToken cancellationToken)
        {
            var synonyms = request.Adapt<CreateSynonyms>();
            synonyms.Term = synonyms.Term.ToLower();
            synonyms.Synonyms = synonyms.Synonyms
                .Select(syn => syn.ToLower())
                .ToList();

            await this.synonymsRepository.Create(synonyms);
            return Unit.Value;
        }
    }
}