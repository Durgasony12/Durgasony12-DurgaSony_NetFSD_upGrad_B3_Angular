using Microsoft.EntityFrameworkCore;
using MovieEntity = Movie.Models.Movie;
namespace Movie.Repositories
{
    public interface IMovieRepository
    {
        IEnumerable<MovieEntity> GetAll();
        MovieEntity GetById(int id);
        void Add(MovieEntity Movie);
        void Update(MovieEntity Movie);
        void Delete(int id);
    }
}
