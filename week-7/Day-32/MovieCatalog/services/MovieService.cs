using Microsoft.EntityFrameworkCore;
using MovieEntity = Movie.Models.Movie;
using Movie.Repositories;
namespace Movie.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repository;

        public MovieService(IMovieRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<MovieEntity> GetMovies()
        {
            return _repository.GetAll();
        }
        public MovieEntity GetMovieById(int id)
        {
            return _repository.GetById(id);
        }
        public void CreateMovie(MovieEntity movie)
        {
            _repository.Add(movie);
        }

        public void UpdateMovie(MovieEntity movie)
        {
            _repository.Update(movie);
        }

        public void DeleteMovie(int id)
        {
            _repository.Delete(id);
        }


    }
}
