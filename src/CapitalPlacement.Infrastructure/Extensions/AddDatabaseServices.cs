using CapitalPlacement.Infrastructure.Database;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CapitalPlacement.Infrastructure.Extensions
{
    public static class AddDatabaseServices
    {
        public static async Task AddDatabaseConnection(this IServiceCollection services, string connectionString, string databaseId)
        {
            using (CosmosClient client = new CosmosClient(connectionString))
            {
                await client.CreateDatabaseIfNotExistsAsync(id: databaseId);
            }

            services.AddDbContextFactory<CosmosDbContext>(optionsBuilder =>
              optionsBuilder
                .UseCosmos(
                  connectionString: connectionString,
                  databaseName: databaseId,
                  cosmosOptionsAction: options =>
                  {
                      options.ConnectionMode(Microsoft.Azure.Cosmos.ConnectionMode.Direct);
                      options.MaxRequestsPerTcpConnection(16);
                      options.MaxTcpConnectionsPerEndpoint(32);
                  }));
        }
    }
}
