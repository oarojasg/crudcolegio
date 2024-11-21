
using CrudColegio.Domain.Database;
using CrudColegio.Domain.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("CrudColegio")));
// Add services to the container.
builder.Services.AddScoped<IAlumnoService, AlumnoService>();
builder.Services.AddScoped<IProfesorService, ProfesorService>();
builder.Services.AddScoped<IGradoService, GradoService>();
builder.Services.AddScoped<ISalonService, SalonService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        await SeedData.Initialize(services);
    }
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enable CORS
app.UseCors(x => x
   .AllowAnyMethod()
   .AllowAnyHeader()
   .SetIsOriginAllowed(origin => true) // allow any origin  
   .AllowCredentials());               // allow credentials 


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
