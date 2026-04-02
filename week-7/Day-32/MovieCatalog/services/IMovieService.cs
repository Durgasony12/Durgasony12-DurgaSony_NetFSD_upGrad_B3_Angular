using MovieEntity = Movie.Models.Movie;
namespace Movie.Services
{
    public interface IMovieService
    {
        IEnumerable<MovieEntity> GetMovies();
        MovieEntity GetMovieById(int id);
        void CreateMovie(MovieEntity Movie);
        void UpdateMovie(MovieEntity Movie);
        void DeleteMovie(int id);
    }
}
