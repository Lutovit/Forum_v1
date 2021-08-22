using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forum_v1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;

namespace Forum_v1.Controllers
{
    public class ManageController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public ManageController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public async Task<ActionResult> Index()
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(User.Identity.Name);

            if (user != null)
            {
                var model = new ManageIndexViewModel
                {
                    ClientName = user.ClientName,
                    CompanyName = user.CompanyName,
                    Email = user.Email
                };

                return View(model);

            }
            else
            {
                ModelState.AddModelError("", "Пользователь не найден");
            }
            return RedirectToAction("Index", "Home");
        }



        [Authorize]
        [HttpGet]
        public async Task<ActionResult> ChangeRegisterData()
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(User.Identity.Name);

            if (user != null)
            {
                ChangeRegisterDataViewModel m = new ChangeRegisterDataViewModel
                {
                    ClientName = user.ClientName,
                    CompanyName = user.CompanyName,
                    Email = user.Email
                };

                return View(m);
            }

            return RedirectToAction("Login", "Account");
        }




        [Authorize]
        [HttpPost]
        public async Task<ActionResult> ChangeRegisterData(ChangeRegisterDataViewModel m)
        {
            if (ModelState.IsValid) 
            {
                ApplicationUser user = await _userManager.FindByEmailAsync(User.Identity.Name);

                if (user != null)
                {
                    user.ClientName = m.ClientName;
                    user.CompanyName = m.CompanyName;
                    user.Email = m.Email;
                    user.UserName = m.Email;

                    IdentityResult result = await _userManager.UpdateAsync(user);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Manage");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Что-то пошло не так");
                    }

                }
                else
                {
                    ModelState.AddModelError("", "Пользователь не найден");
                }


            }

            return View(m);
        }

        


        // GET: /Manage/ChangePassword
        public ActionResult ChangePassword()
        {
            return View();
        }

        


        //
        // POST: /Manage/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _userManager.ChangePasswordAsync(await _userManager.FindByNameAsync(User.Identity.Name), model.OldPassword, model.NewPassword);

            if (result.Succeeded)
            {
                /*
                var user = await _userManager.FindByNameAsync(User.Identity.Name);

                if (user != null)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false, authenticationMethod: null );
                }
                */

                await _signInManager.SignOutAsync();

                return View("YourPasswordChanged");
            }
            else
            {
                ModelState.AddModelError("", "Что-то пошло не так");
            }

            return View(model);
        }
    }
}