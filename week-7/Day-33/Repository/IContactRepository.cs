using WebApplication2.Models;
namespace WebApplication2.Repositories
{
    public interface IContactRepository
    {
        IEnumerable<Contacts> GetAll();
        Contacts GetById(int id);
        void Add(Contacts contact);
         
    }
}
