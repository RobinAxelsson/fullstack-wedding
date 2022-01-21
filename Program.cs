using System.Text.Json;
using Microsoft.Azure.Cosmos.Table;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

app.UseHttpsRedirection();

app.MapPost("api/guest", async (Guest guest) =>
{
    guest.RowKey = Guid.NewGuid().ToString("d");
    guest.PartitionKey = guest.MyPreferedLanguage;

    Console.WriteLine(guest.ToString());
    var repo = new Repository();
    await repo.InsertGuest(guest);
    
    return Results.StatusCode(202);
});
app.MapPost("api/song", (Song song) =>
{
    Console.WriteLine(song.ToString());
    return Results.StatusCode(202);
});
app.MapPost("api/memory", (Memory memory) =>
{
    Console.WriteLine(memory.ToString());
    return Results.StatusCode(202);
});
app.MapGet("api/test", () => "Hello World");
// app.MapPost("/picture", () => {
//     return Results.StatusCode(202);
// });

app.Run();


// public record Picture