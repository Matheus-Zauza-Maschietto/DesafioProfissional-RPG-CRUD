using Microsoft.EntityFrameworkCore;
using RpgApi.Middlewares;
using RpgApi.Repository;
using RpgApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services
    .AddDbContext<ApplicationDbContext>(
        p => p.UseInMemoryDatabase("InMemoryDatabase")
    );
builder.Services.AddScoped<PersonagemRepository>();
builder.Services.AddScoped<PersonagemService>();
builder.Services.AddScoped<ItemMagicoRepository>();
builder.Services.AddScoped<ItemMagicoService>();

var app = builder.Build();
app.UseExceptionHandler();
app.MapOpenApi();
app.UseHttpsRedirection();
app.MapControllers();
app.MapSwagger();
app.UseSwaggerUI(p => p.SwaggerEndpoint("swagger", "Rpg"));
app.Run();
