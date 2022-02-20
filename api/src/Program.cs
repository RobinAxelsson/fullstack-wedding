var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

if(config.GetValue<bool>("Database:Local")) 
    config["ConnectionString"] = "UseDevelopmentStorage=true";

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

if(builder.Configuration.GetValue<bool>("Email:Enabled"))
    builder.Services.AddSingleton<IMessageClient, EmailClient>();
else
    builder.Services.AddSingleton<IMessageClient, FakeEmailClient>();

if(builder.Configuration.GetValue<bool>("Database:Enabled"))
    builder.Services.AddSingleton<IRepository, Repository>();
else
    builder.Services.AddSingleton<IRepository, FakeRepository>();

builder.Services.AddSingleton<HtmlParser>();


Console.WriteLine("Password: " + config["Email:Password"]);
Console.WriteLine("Email: " + config["Email:Address"]);
Console.WriteLine("ConnectionString: " + config["ConnectionString"]);
Console.WriteLine($"Application Name: {builder.Environment.ApplicationName}");
Console.WriteLine($"Environment Name: {builder.Environment.EnvironmentName}");
Console.WriteLine($"ContentRoot Path: {builder.Environment.ContentRootPath}");
Console.WriteLine($"WebRootPath: {builder.Environment.WebRootPath}");

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("index.html");

app.MapGet("api/test", () => "Hello World");

app.Run();
