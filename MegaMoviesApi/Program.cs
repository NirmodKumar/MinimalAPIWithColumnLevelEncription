using MegaMoviesApi.Common;
using MegaMoviesApi.Providers.SqlServerProvider;
using MegaMoviesApi.Services.Implementations;
using MegaMoviesApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IMovieService, MovieService>();

var connectionString = builder.Configuration.GetValue<string>(CommonConstants.SQLConnectionString);

builder.Services.AddDbContext<MegaMovieDbContext>(option =>
 option.UseSqlServer(connectionString, contextBuilder =>
 {
     contextBuilder.EnableRetryOnFailure(3);
 }));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapGet("/TestMinimalApi", () => { return "It is working!"; });
app.MapGet("/GetAllMovies",
    async (IMovieService movieService) =>
    {
        return await movieService.GetMovies();
    });

app.Run();
