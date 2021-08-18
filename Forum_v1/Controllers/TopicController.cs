using Forum_v1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repository.Absract;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum_v1.Controllers
{
    public class TopicController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IGenericRepository<Topic> _topicRepo;


        public TopicController(UserManager<ApplicationUser> userManager, IGenericRepository<Topic> topicRepo)
        {
            _userManager = userManager;
            _topicRepo = topicRepo;
        }



        public async Task<IActionResult> Index() 
        {
            return View(await _topicRepo.GetAllAsync());
        }



        [HttpGet]
        [Authorize]
        public IActionResult CreateTopic() 
        {
            return View();        
        }



        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateTopic(TopicCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await _userManager.FindByEmailAsync(User.Identity.Name);

                if (user == null) 
                {
                    ModelState.AddModelError(string.Empty, "Объект User  не найден!");
                }

                Topic topic = new Topic {  TopicName = model.TopicName, TopicDescription = model.TopicDescription, User = user, ApplicationUserId = user.Id };

                if (topic == null) 
                {
                    ModelState.AddModelError(string.Empty, "Объект Topic не создан!");
                }

                await _topicRepo.CreateAsync(topic);

                return RedirectToAction("Index", "Topic");

            }
            return View(model);
        }
    }
}
