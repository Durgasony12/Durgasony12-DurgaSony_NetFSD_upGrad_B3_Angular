using Microsoft.AspNetCore.Mvc;
using ContactManagement.Models;
using System.Text.Json;

namespace ContactManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private static List<Contact> contacts = new List<Contact>();
        private readonly HttpClient _httpClient;

        public ContactController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        [HttpPost]
        public async Task<IActionResult> Add(Contact contact)
        {

            var response = await _httpClient.GetAsync(
                $"https://localhost:7260/api/category/{contact.CategoryId}");

            if (!response.IsSuccessStatusCode)
                return BadRequest("Invalid CategoryId");

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var categoryData = await response.Content.ReadFromJsonAsync<object>(options);

            if (categoryData == null)
                return BadRequest("Category not found");

            contacts.Add(contact);
            return Ok(contact);
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var contact = contacts.FirstOrDefault(c => c.ContactId == id);

            if (contact == null)
                return NotFound();

            return Ok(contact);
        }
 
       
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Contact updated)
        {
            var contact = contacts.FirstOrDefault(c => c.ContactId == id);

            if (contact == null)
                return NotFound();

            contact.Name = updated.Name;
            contact.Email = updated.Email;
            contact.Phone = updated.Phone;
            contact.CategoryId = updated.CategoryId;

            return Ok(contact);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var contact = contacts.FirstOrDefault(c => c.ContactId == id);

            if (contact == null)
                return NotFound();

            contacts.Remove(contact);
            return Ok();
        }
    }
}