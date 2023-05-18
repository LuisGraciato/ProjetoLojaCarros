using AutoMapper;
using DevIOApi.Configuration;
using DevIoData.Context;
using LojaCarrosApi.Configuration;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Configuração do DbContext
builder.Services.AddDbContext<MyDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// IdentityConfig
builder.Services.AddIdentityConfiguration(builder.Configuration);

// JWTConfig
builder.Services.AddJwtConfiguration(builder.Configuration);

// Configuração do AutoMapper
var mapperConfig = new MapperConfiguration(config =>
{
    config.AddProfile(new AutomapperConfig());
});
var mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.ResolveDependencies();

builder.Services.AddControllers();

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure o pipeline de requisições HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
