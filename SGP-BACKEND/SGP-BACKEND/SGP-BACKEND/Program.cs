using Microsoft.EntityFrameworkCore;
using SGP_BACKEND.Services;
using SGP_DATOS;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSwaggerGen(options =>
{
     
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "SGP SWAGGER",
        Description = "SWAGGER DOCUMENT FOR SGP API",
        Version = "v1"
    });
    var fileName = Assembly.GetExecutingAssembly().GetName().Name + ".xml";
    var filePath = Path.Combine(AppContext.BaseDirectory, fileName);
    options.IncludeXmlComments(filePath);
});
builder.Services.AddDbContext<AppDbContext>(context =>
{
    context.UseSqlServer(builder.Configuration.GetConnectionString("Conexion"));
});
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "OrigenesPermitidos",
        builder =>
        {
            //builder.WithOrigins(SpecificOrigins.MyOrigins());
            builder.AllowAnyOrigin();
            builder.AllowAnyMethod();
            builder.AllowAnyHeader();
        });
});


builder.Services.AddRepositorios();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
 

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
