using WebApplication2.Models;
namespace WebApplication2.Services
{
    public interface IContactService
    {
        IEnumerable<Contacts> GetAllContacts();
        Contacts GetContactById(int id);
        //void AddContact(Contacts contact);
        void Create(Contacts Contact);
    }
}
