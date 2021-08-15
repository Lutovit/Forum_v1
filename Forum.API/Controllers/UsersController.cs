using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;


        public UsersController(UserManager<ApplicationUser> userManager) 
        {
            _userManager = userManager;      
        }



        [HttpGet]
        public IEnumerable<ApplicationUser> Get()
        {
            return _userManager.Users;
        }


        // GET api/users/email
        [HttpGet("{email}")]
        public async Task<ActionResult<ApplicationUser>> Get(string email)
        {
            ApplicationUser user = await _userManager.FindByNameAsync(email);

            if (user == null) 
            {
                return NotFound();
            }
                
            return new ObjectResult(user);
        }


    }
}
