

using Services.Customer.Handlers;
using str.Entities.Dto;
using StreamReader.Infrastruce;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddKafkaConsumer<string, ProductViewDto, StreamConsumerHandler>(p =>
{
    var configuration = builder.Configuration;
    p.Topic = configuration.GetSection("Kafka")["Topic"];  // "productview"
    p.GroupId = configuration.GetSection("Kafka")["GroupId"]; //"users_group"
    p.BootstrapServers = configuration.GetSection("Kafka")["BootstrapServers"]; //"localhost:9092"

});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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
