using MegaMoviesApi.Providers.SqlServerProvider;

namespace MegaMoviesApi.Services.Implementations
{
    public interface IMovieService
    {
        Task<IList<Movie>> GetMovies();
    }
}