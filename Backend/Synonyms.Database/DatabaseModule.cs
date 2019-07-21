using System;
using Autofac;
using Mapster;
using Synonyms.Database.Models;

namespace Synonyms.Database
{
    public class DatabaseModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AppContext>()
                .AsSelf()
                .InstancePerDependency();

            builder.RegisterType<SynonymsRepository>()
                .As<ISynonymsRepository>()
                .InstancePerDependency();
            
            builder.RegisterType<DatabaseSettings>()
                .AsSelf()
                .InstancePerDependency();
            
            var mapsterConfig = TypeAdapterConfig.GlobalSettings;
            mapsterConfig.ForType<CreateSynonyms, SynonymsRecord>()
                .Map(dst => dst.Synonyms, src => string.Join(',', src.Synonyms))
                .Compile();
            
            mapsterConfig.ForType<SynonymsRecord, GetSynonyms>()
                .Map(dst => dst.Synonyms, src => src.Synonyms.Split(",", StringSplitOptions.None))
                .Compile();
        }
    }
}