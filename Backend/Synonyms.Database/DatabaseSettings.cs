using Microsoft.Extensions.Configuration;

namespace Synonyms.Database
{
    public class DatabaseSettings
    {
        private readonly IConfiguration configuration;

        public DatabaseSettings(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string ConnectionString => this.configuration["Database:ConnectionString"];
    }
}