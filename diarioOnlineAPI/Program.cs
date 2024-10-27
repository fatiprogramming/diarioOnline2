using Microsoft.EntityFrameworkCore;
using diarioOnlineAPI.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Configurar la conexi�n a la base de datos SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddHttpClient("API", client =>
{
    client.BaseAddress = new Uri("http://localhost:7090/"); // Aseg�rate de que esta URL sea correcta
});
// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin()
                         .AllowAnyMethod()
                         .AllowAnyHeader());
});

// Agregar controladores
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Usar CORS
app.UseCors("AllowAll");
// Configuraci�n de Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "diarioOnlineAPI v1");
    c.RoutePrefix = "swagger";
});

// Configurar el middleware
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();