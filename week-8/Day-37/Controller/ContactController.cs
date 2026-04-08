using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication6.Models;
namespace WebApplication6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private static List<ContactInfo> contacts = new List<ContactInfo>()
        {
            new ContactInfo {ContactId = 1,FirstName="Durga", LastName="Sony",EmailId="Sony@gmail.com",MobileNo=4563217895,Designation="Developer",CompanyId=1,DepartmentId=1},

            new ContactInfo {ContactId = 2,FirstName="Priya", LastName="Harshi",EmailId="priya@gmail.com",MobileNo=4789517895,Designation="Tester",CompanyId=2,DepartmentId=2}
        };

        [HttpGet]
        public IActionResult GetContacts()
        {
            return Ok(contacts);
        }
        [HttpGet("{id}")]
        public IActionResult GetContactById(int id)
        {
            var contact = contacts.Find(item=> item.ContactId == id);

            if (contact == null)
            {
                return Ok("contact info not found");
            }
            else
            {
                return Ok(contact);
            }
        }
        [HttpPost]
        public IActionResult AddContact(ContactInfo contact)
        {
            contacts.Add(contact);
            return Ok(new { contact, Status = "Contact added successfully." });
        }
        [HttpPut("{id}")]
        public IActionResult UpdateContact( int id, ContactInfo contact)
        {
            var oldcontact = contacts.Find(item=> item.ContactId == id) ;
            if(oldcontact == null)
            {
                return Ok("requested contact is not found");
            }
            else
            {
                oldcontact.FirstName = contact.FirstName;
                oldcontact.LastName= contact.LastName;
                oldcontact.EmailId = contact.EmailId;
                oldcontact.MobileNo = contact.MobileNo;
                oldcontact.Designation= contact.Designation;
                oldcontact.CompanyId= contact.CompanyId;
                oldcontact.DepartmentId= contact.DepartmentId;
                return Ok("Contact updated successfully");
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var contact = contacts.Find(item=> item.ContactId == id);
            if(contact == null)
            {
                return Ok("Contact not found");
            }
            else
            {
                contacts.Remove(contact);
                return Ok("Removed contact successfully");

            }
        }
    }
}
