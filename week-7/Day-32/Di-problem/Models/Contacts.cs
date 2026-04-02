using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication2.Models
{
    public class Contacts
    {
        
        public int ContactId { get; set; }  // Primary Key
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string EmailId { get; set; }
        public long MobileNo { get; set; }
        public string Designation { get; set; } 
    }
}
