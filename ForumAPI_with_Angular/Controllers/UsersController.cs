using ForumAPI_with_Angular.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAPI_with_Angular.Controllers
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
        public IEnumerable<UserTranferObject> Get()
        {
            IEnumerable<ApplicationUser> userList = _userManager.Users;

            List<UserTranferObject> userTransferList = new List<UserTranferObject>();

            foreach (var user in userList)
            {
                UserTranferObject userTransferObj = new UserTranferObject
                {
                    Id = user.Id.ToString(),
                    ClientName = user.ClientName,
                    CompanyName = user.CompanyName,
                    Email = user.Email,
                    DateOfRegistration = user.DateOfRegistration.ToString(),
                    isBanned = user.isBanned,
                    isDelited = user.isDelited
                };

                userTransferList.Add(userTransferObj);
            }

            return userTransferList;
        }


        // GET api/users/email
        [HttpGet("{email}")]
        public async Task<ActionResult<UserTranferObject>> Get(string email)
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
