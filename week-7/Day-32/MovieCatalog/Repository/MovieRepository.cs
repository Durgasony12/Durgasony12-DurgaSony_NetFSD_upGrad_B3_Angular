using Microsoft.EntityFrameworkCore;
using MovieEntity = Movie.Models.Movie;
namespace Movie.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _context;

        public MovieRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<MovieEntity> GetAll()
        {
            return _context.Movies.ToList();
        }
        public MovieEntity GetById(int id)
        {
            return _context.Movies.Find(id);
        }
        public void Add(MovieEntity Movie)
        {
            _context.Movies.Add(Movie);
            _context.SaveChanges();
        }
        public void Update(MovieEntity Movie)
        {
            _context.Movies.Update(Movie);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var movie = _context.Movies.Find(id);

            if (movie != null)
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
            }
        }
    }
}
