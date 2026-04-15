using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CategoryManagement.Models;
namespace CategoryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private static List<Category> categories = new List<Category>();
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            categories.Add(category);
            return Ok(category);
        }
        [HttpGet]
        public IActionResult GetAllCategory()
        {
            return Ok(categories);
        }
        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            var category = categories.Find(item => item.CategoryId == id);
            if (category == null)
            {
                return NotFound("Requested category does not exists");
            }
            else
            {
                return Ok(category);
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, Category category)
        {
            var oldcategory = categories.Find(item=>  item.CategoryId == id);
            if(oldcategory == null)
            {
                return NotFound("requested category not found");
            }
            else
            {
                oldcategory.CategoryId = category.CategoryId;
                oldcategory.CategoryName = category.CategoryName;
                oldcategory.Description = category.Description;
                return Ok(new { updatedCategory = oldcategory, status = "Category details are updated successfully in server..!" });
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = categories.Find(item => item.CategoryId == id);
            if (category == null)
            {
                return NotFound("Requested category does not exists");
            }
            else
            {
                categories.Remove(category);
                return Ok(new { category, status = "category details are deleted"});
            }
        }

    }
}
