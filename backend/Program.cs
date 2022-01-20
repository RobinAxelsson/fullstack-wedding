using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

app.MapPost("/guest", async (Guest guest) => {
    guest.RowKey = Guid.NewGuid().ToString("d");
    guest.PartitionKey = guest.MyPreferedLanguage;

    Console.WriteLine(guest.ToString());
    
    var repository = new Repository();
    //var response = await repository.AddOrUpdateGuest(guest); breaks
    //Console.WriteLine("response: ", response);

    return Results.StatusCode(202);
});
app.MapPost("/song", (Song song) => {
    Console.WriteLine(song.ToString());
    return Results.StatusCode(202);
});
app.MapPost("/memory", (Memory memory) => {
    Console.WriteLine(memory.ToString());
    return Results.StatusCode(202);
});
// app.MapPost("/picture", () => {
//     return Results.StatusCode(202);
// });

app.Run();


// public record Picture