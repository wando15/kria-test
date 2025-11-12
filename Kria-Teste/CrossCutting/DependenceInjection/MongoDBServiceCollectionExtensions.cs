using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Infrastructure.ConfigurationRoot;
namespace CrossCutting.DependenceInjection
{
    public static class MongoDBServiceCollectionExtensions
    {
        public static IServiceCollection AddMongoDB(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IMongoClient>(serviceProvider =>
            {
                var connectionString = configuration.GetConnectionString("mongoDB");
                return new MongoClient(connectionString);
            });

            services.AddDbContext<MongoDbContext>((provider, options) =>
            {
                var client = provider.GetRequiredService<IMongoClient>();
                var dbName = configuration.GetSection("dbName").Value 
                             ?? throw new InvalidOperationException("A configuração 'dbName' não foi encontrada ou está nula.");
                
                options.UseMongoDB(client, dbName);
            });

            return services;
        }
    }
}
