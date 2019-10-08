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
    public class DetailsController : ControllerBase
    {
        private readonly PracticeContext _context;

        public DetailsController(PracticeContext context)
        {
            _context = context;
        }

        //get: api/Details/id

        [HttpGet]
        public IEnumerable<OrderDetail> GetOrderDetail()
        {
            return _context.OrderDetails;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDetail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var order = await _context.Products.FindAsync(id);
            

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }


    }
}