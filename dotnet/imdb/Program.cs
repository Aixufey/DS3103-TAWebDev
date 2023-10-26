using imdb.Contexts;
using imdb.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MovieContext>(options => options.UseSqlite("Data Source=Movies.db"));
builder.Services.AddCors(
    // Granting access to this API
    options => {
        // Giving a logical name "AllowAll" to open this for public
        options.AddPolicy("AllowAll", 
            builder => builder
                .AllowAnyHeader() // Allowing Header information to be passed 
                .AllowAnyMethod() // Allowing CRUD operations
                .AllowAnyOrigin() // Allowing all domains
        );
    }
);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
