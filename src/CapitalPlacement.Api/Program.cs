using CapitalPlacement.Api.Middleware;
using CapitalPlacement.Core.Interface.Repositories;
using CapitalPlacement.Core.Services;
using CapitalPlacement.Infrastructure.Database;
using CapitalPlacement.Infrastructure.Repositories;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.Configure<CosmosDbSettings>(builder.Configuration.GetSection("CosmosDb"));
//builder.Services.AddSingleton<CosmosDbInitializer>();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
var databaseId = "CapitalPlacementDb";
using (CosmosClient client = new CosmosClient(connectionString))
{
    var db = await client.CreateDatabaseIfNotExistsAsync(id: databaseId);
    await db.Database.CreateContainerIfNotExistsAsync("Programs", "/Id");
    await db.Database.CreateContainerIfNotExistsAsync("Questions", "/QuestionType");
    await db.Database.CreateContainerIfNotExistsAsync("CandidateApplications", "/Id");
}

builder.Services.AddDbContextFactory<CosmosDbContext>(optionsBuilder =>
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

builder.Services.AddScoped<IProgramRepository, ProgramRepository>();
builder.Services.AddScoped<ProgramService>();
builder.Services.AddScoped<CandidateApplicationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ExceptionMiddleware>();

app.Run();
