using WebApplication2.Models;
using Microsoft.EntityFrameworkCore;
namespace WebApplication2.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ApplicationDbContext _context;

        public ContactRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Contacts> GetAll()
        {
            return _context.Contacts.ToList();
        }

        public Contacts GetById(int id)
        {
            return _context.Contacts.Find(id);
        }
        public void Add(Contacts Contact)
        {
            _context.Contacts.Add(Contact);
            _context.SaveChanges();
        }
    }
}
