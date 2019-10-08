using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TrialProject.Entities;

namespace TrialProject.Controllers.signin
{
    [Route("api/[controller]")]
    [ApiController]
    public class loginuserController : ControllerBase
    {
        private readonly PracticeContext _privatecontext;
        public loginuserController(PracticeContext practiceContext)
        {
            _privatecontext = practiceContext;
        }


   




        [HttpPost]
        [Route("Login")]
        //POST:/api/loginuser/Login



        public async Task<IActionResult> Login([FromBody] User user)
        {
            bool isValid = _privatecontext.Users.Any(x => x.Uname==user.Uname && x.Password==user.Password);
            //var user = await _userManager.FindByNameAsync(model.UserName);
            User userObject;
            try
            {
                userObject = _privatecontext.Users.Where(x => x.Uname == user.Uname && x.Password == user.Password).Single();
            }
            catch(Exception e) { throw e; }  
            if (isValid)
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UId",userObject.UId.ToString()),
                         new Claim(ClaimTypes.Role,userObject.UserRole)
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("1234567890123456")), SecurityAlgorithms.HmacSha256Signature)
                    
                };

               

                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token ,userObject.UId,userObject.UserRole});
            }
            else
            {
                return BadRequest(new { message = "username is incorrect" });
            }
        }

    }



}