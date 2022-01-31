var builder = WebApplication.CreateBuilder(args);

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

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("api/test", () => "Hello World");

app.Run();
