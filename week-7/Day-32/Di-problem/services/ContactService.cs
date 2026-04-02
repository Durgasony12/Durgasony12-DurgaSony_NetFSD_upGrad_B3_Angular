using WebApplication2.Models;
using WebApplication2.Repositories;
namespace WebApplication2.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _repository;

        public ContactService(IContactRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<Contacts> GetAllContacts()
        {
            return _repository.GetAll();
        }

        public Contacts GetContactById(int id)
        {
            return _repository.GetById(id);
        }
        public void Create(Contacts contact)
        {
            _repository.Add(contact);
        }

    }
}
