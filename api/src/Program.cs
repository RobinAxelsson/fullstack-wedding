var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

if(config.GetValue<bool>("Database:Local")) 
    config["ConnectionString"] = "UseDevelopmentStorage=true";

builder.Services.AddControllers();

builder.Services.AddApplicationInsightsTelemetry(config);

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

builder.Services.AddHealthChecks();


var app = builder.Build();

var logger = app.Services.GetRequiredService<ILogger<Program>>();

logger.LogInformation("Password: " + config["Email:Password"]);
logger.LogInformation("Email: " + config["Email:Address"]);
logger.LogInformation("ConnectionString: " + config["ConnectionString"]);
logger.LogInformation($"Application Name: {builder.Environment.ApplicationName}");
logger.LogInformation($"Environment Name: {builder.Environment.EnvironmentName}");
logger.LogInformation($"ContentRoot Path: {builder.Environment.ContentRootPath}");
logger.LogInformation($"WebRootPath: {builder.Environment.WebRootPath}");


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

app.MapHealthChecks("/healthz");

app.Run();
