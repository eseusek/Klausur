using Microsoft.Extensions.Azure;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Use Azurite emulator for local Azure Storage development | Microsoft Docs
//https://docs.microsoft.com/en-us/azure/cosmos-db/local-emulator?tabs=ssl-netstd21

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAzureClients(clientBuilder =>
{
    clientBuilder.AddBlobServiceClient(builder.Configuration["mylocalconnection:blob"], preferMsi: true);
    clientBuilder.AddQueueServiceClient(builder.Configuration["mylocalconnection:queue"], preferMsi: true);
});

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

app.Run();
