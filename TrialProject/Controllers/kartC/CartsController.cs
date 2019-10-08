using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrialProject;
using TrialProject.Models;
using TrialProjectEntities;




namespace TrialProject.Controllers.KartC
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {



        PracticeContext db = new PracticeContext();
        CartBLL c = new CartBLL();





        [HttpPost("getCart")]



        public IEnumerable<Cart> Get([FromBody] Cart model)
        {
            var result = c.GetCartValue(model);
            return result;
        }




        [HttpGet]



        public async Task<ActionResult<IEnumerable<Cart>>> Get()
        {
            return await db.Carts.ToListAsync();
        }




        [HttpPost]
        public IActionResult Post([FromBody] Cart model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("data invalid");
            }
            else
            {
                bool isValid = c.AddCart(model);
                if (isValid == true)
                    return Ok();
                else
                    return NotFound();
            }





        }



        [HttpPost("remove")]
        public string PostC([FromBody]Cart model)
        {
            if (c.RemoveFromCart(model))
            {
                Success _success = new Success();
                {
                    _success.Succeed = true;
                };



                return Newtonsoft.Json.JsonConvert.SerializeObject(_success);



            }
            else
            {
                Success _success = new Success();
                {
                    _success.Succeed = false;
                };
                return Newtonsoft.Json.JsonConvert.SerializeObject(_success);
            }





        }




    }
}