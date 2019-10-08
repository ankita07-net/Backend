using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrialProjectEntities;

namespace TrialProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryproductController : ControllerBase
    {
        PracticeContext db = new PracticeContext();

        public CategoryproductController(PracticeContext practiceContext)
        {
            db = practiceContext;
        }

        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return db.Products;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProducts (int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var category = db.Products.Where(x => x.CId == id).ToArray();
            return Ok(category);

        }







    }
}