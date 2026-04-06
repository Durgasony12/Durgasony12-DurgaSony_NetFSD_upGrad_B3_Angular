using WebApplication5.Models;
namespace WebApplication5.Repositories
{
    public interface IContactRepository
    {
        List<Contact> GetAllContacts();
        Contact GetContactById(int id);
        void Add(Contact contact);
        void Update(Contact contact);
        void Delete(int id);
        List<Company> GetAllCompanies();
        List<Department> GetAllDepartments();
    }
}
