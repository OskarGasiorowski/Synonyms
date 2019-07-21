using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Synonyms.Database.Models;

namespace Synonyms.Database
{
    public interface ISynonymsRepository
    {
        Task Create(CreateSynonyms data);
        Task<IReadOnlyList<GetSynonyms>> Get();
    }
    
    public class SynonymsRepository : ISynonymsRepository
    {
        private readonly AppContext context;

        public SynonymsRepository(AppContext context)
        {
            this.context = context;
        }

        public Task Create(CreateSynonyms data)
        {
            this.context.Add(data.Adapt<SynonymsRecord>());
            return this.context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<GetSynonyms>> Get()
        {
            return (await this.context.Synonyms
                .ToListAsync())
                .Adapt<IReadOnlyList<GetSynonyms>>();
        }
    }
}