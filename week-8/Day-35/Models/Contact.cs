using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    public class Contact
    {
        public int Id { get; set; }  // Primary Key
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public long MobileNo { get; set; }
        public string Designation { get; set; }

        public int CompanyId { get; set; }

        public int DepartmentId { get; set; }

    }
}
