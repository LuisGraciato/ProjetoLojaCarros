using LojaCarrosApi.Configuration;

var builder = WebApplication.CreateBuilder(args);

// IdentityConfig

builder.Services.AddIdentityConfiguration(builder.Configuration);

// JWTConfig

builder.Services.AddJwtConfiguration(builder.Configuration);

builder.Services.AddControllers();


// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipelinesw.
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
