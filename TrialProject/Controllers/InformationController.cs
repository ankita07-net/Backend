using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrialProject.Entities;

namespace TrialProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformationController : ControllerBase
    {
        PracticeContext pC = new PracticeContext();

        public InformationController(PracticeContext practiceContext)
        {
            pC = practiceContext;
        }

        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return pC.Users;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = pC.Users.Where(x => x.UId == id).FirstOrDefault();
            return Ok(user);
        }

    }
}