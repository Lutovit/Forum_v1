using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forum_v1.Models;
using Forum_v1.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Repository.Entities;

namespace Forum_v1.Controllers
{
    public class RoleController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        private IAdminConfigService _adminService;


        public RoleController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IAdminConfigService adminConfigService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _adminService = adminConfigService;            
        }



        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            return View(_roleManager.Roles);
        }



        [Authorize]
        public async Task<ActionResult> UsersRoles()
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(User.Identity.Name);

            if (user != null)
            {
                IList<string> _roleslist = await _userManager.GetRolesAsync(user);

                return View(_roleslist);
            }
            return RedirectToAction("Login", "Account");

        }


        [Authorize]
        public async Task<ActionResult> BecomeAdmin()
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(User.Identity.Name);


            if (user != null && user.Email == _adminService.adminEmail)
            {

                IdentityRole roleAdmin = await _roleManager.FindByNameAsync("admin");


                if (roleAdmin == null)
                {
                    IdentityResult result = await _roleManager.CreateAsync(new IdentityRole
                    {
                        Name = "admin"
                    });

                    if (!result.Succeeded)
                    {
                        ModelState.AddModelError("", "Что-то пошло не так");
                    }

                }


                await _userManager.AddToRoleAsync(user, "admin");

                return RedirectToAction("Log_Off", "Account");
            }
            else
            {
                return RedirectToAction("WrongEmailToBecomeAdmin", "Role");
            }
        }



        [Authorize]
        public ActionResult WrongEmailToBecomeAdmin()
        {
            return View();
        }




        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }



        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<ActionResult> Create(CreateRoleModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole
                {
                    Name = model.Name
                });

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Что-то пошло не так");
                }

            }
            return View(model);
        }



        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Edit(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);

            if (role != null)
            {
                return View(new EditRoleModel { Id = role.Id, Name = role.Name });
            }

            return RedirectToAction("Index");
        }



        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<ActionResult> Edit(EditRoleModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = await _roleManager.FindByIdAsync(model.Id);

                if (role != null)
                {
                    role.Name = model.Name;

                    IdentityResult result = await _roleManager.UpdateAsync(role);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Что-то пошло не так");
                    }
                }
            }
            return View(model);
        }




        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult DeleteRole()
        {
            return View();
        }



        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<ActionResult> DeleteRole(string id)
        {
           IdentityRole role = await _roleManager.FindByIdAsync(id);

            if (role != null)
            {
                IdentityResult result = await _roleManager.DeleteAsync(role);
            }
            return RedirectToAction("Index");
        }

        


        [Authorize(Roles = "admin")]
        public async Task<ActionResult> AddUserToRole(string Email, string rolename)
        {

            ApplicationUser user = await _userManager.FindByEmailAsync(Email);

            if (user != null)
            {
                await _userManager.AddToRoleAsync(user, rolename);

                return RedirectToAction("Info", "Admin");
            }
            else
            {
                ModelState.AddModelError("", "Что-то пошло не так");
            }

            return RedirectToAction("Index", "Admin");

        }

    }
}