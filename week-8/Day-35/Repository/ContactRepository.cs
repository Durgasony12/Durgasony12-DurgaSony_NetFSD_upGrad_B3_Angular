using Dapper;
using Humanizer;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.Design;
using WebApplication5.Models;
namespace WebApplication5.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly string _connStr;
        public ContactRepository(IConfiguration config)
        {
            _connStr = config.GetConnectionString("DefaultConnection");
        }
        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connStr);
        }
        public List<Contact> GetAllContacts()
        {
            string sqlQuery = @"SELECT * FROM Contact";
            var db = GetConnection();
            return db.Query<Contact>(sqlQuery).ToList();

        }
        public Contact GetContactById(int id)
        {
            string sqlQuery = @"
                SELECT * FROM Contact WHERE Id="+id;
            var db = GetConnection();
            return db.QueryFirstOrDefault<Contact>(sqlQuery);
        }
        public void Add(Contact contact)
        {
            string sqlQuery = @"INSERT INTO Contact (FirstName,LastName,EmailId,MobileNo,Designation,CompanyId,DepartmentId) VALUES (@FirstName,@LastName,@EmailId,@MobileNo,@Designation,@CompanyId,@DepartmentId)";

            var db = GetConnection();
            db.Execute(sqlQuery, contact);
        }
        public void Update(Contact contact)
        {
            string sqlQuery = @"UPDATE Contact 
                    SET FirstName=@FirstNmae, LastName=@LastName, EmailId=@EmailId, MobileNo=@MobileNo, Designation=@Designation,CompanyId=@CompanyId,DepartmentId=@DepartmentId
                    WHERE Id=@Id";

            var db = GetConnection();
            db.Execute(sqlQuery, contact);
        }
        public void Delete(int id)
        {
            string sqlQuery = "DELETE  FROM Contact WHERE Id=" + id;

            var db = GetConnection();
            db.Execute(sqlQuery);
        }
        public List<Company> GetAllCompanies()
        {
            string sql = "SELECT CompanyId, CompanyName FROM Company";

            var db = GetConnection();
            return db.Query<Company>(sql).ToList();
        }

        public List<Department> GetAllDepartments()
        {
            string sql = "SELECT DepartmentId, DepartmentName FROM Department";

            var db = GetConnection();
            return db.Query<Department>(sql).ToList();
        }
    }
}
