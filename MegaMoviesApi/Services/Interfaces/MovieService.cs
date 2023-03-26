using MegaMoviesApi.Providers.SqlServerProvider;
using MegaMoviesApi.Services.Implementations;
using Microsoft.EntityFrameworkCore;

namespace MegaMoviesApi.Services.Interfaces
{
    public class MovieService : IMovieService
    {
        private readonly MegaMovieDbContext _dbContext;

        public MovieService(MegaMovieDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<IList<Movie>> GetMovies()
        {
            return await _dbContext.Movies.ToListAsync();
        }
    }
}
