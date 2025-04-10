var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddEntityFrameworkInMemoryDatabase();

var app = builder.Build();

app.MapOpenApi();
app.UseHttpsRedirection();
app.MapControllers();
app.MapSwagger();
app.UseSwaggerUI(p => p.SwaggerEndpoint("swagger", "Rpg"));

app.Run();
