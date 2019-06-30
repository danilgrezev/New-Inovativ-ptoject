using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend5.Models;
using Backend5.Models.MyViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Backend5.Controllers
{


    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        // GET: /Account/Login
        [HttpGet]

        public async Task<IActionResult> Login(String returnUrl = null)
        {
            // Clear the existing external cookie to ensure a clean login process
            await this.HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            this.ViewData["ReturnUrl"] = returnUrl;
            return this.View();
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                   var result = await this.signInManager.PasswordSignInAsync(model.UserName, model.Password, true, lockoutOnFailure: false);
                   if (result.Succeeded)
                   {
                       return this.Redirect("/Home/Index");
                }

                   if (result.IsLockedOut)
                   {
                       return this.View("Lockout");
                   }

                   this.ModelState.AddModelError(String.Empty, "Invalid login attempt.");
                return this.View(model);
            }

            // If we got this far, something failed, redisplay form
            return this.View(model);
        }

        // GET: /Account/Register
        [HttpGet]

        public IActionResult Register(String returnUrl = null)
        {
            this.ViewData["ReturnUrl"] = returnUrl;
            return this.View();
        }

        // POST: /Account/Register
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var user = new ApplicationUser {
                    Email=model.Email,
                    UserName=model.Name,
                    UserTypeId = model.Type,
                    Rating = 1,
                    GeoId = 1
                    
                };
                  var result = await this.userManager.CreateAsync(user, model.Password);
                  if (result.Succeeded)
                  {
                  //  await this.userManager.AddToRoleAsync(user, "Client");
                  //  await this.signInManager.SignInAsync(user, isPersistent: false);
                    return this.Redirect("/Home/Index");
                }

                this.AddErrors(result);
            }

            return this.View(model);
        }

        // POST: /Account/Logout
        public async Task<IActionResult> Logout()
        {
            await this.signInManager.SignOutAsync();
            return this.Redirect("/");
            //
        }

        //[HttpGet]

        //public async Task<IActionResult> userAccount(Int32 userId)
        //{
        //    // Clear the existing external cookie to ensure a clean login process
        //    await this.HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

        //    //this.ViewData["ReturnUrl"] = returnUrl;
        //    return this.View();
        //}

        //// POST: /Account/Login
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> userAccount(LoginViewModel model)
        //{
        //    if (this.ModelState.IsValid)
        //    {
        //        // This doesn't count login failures towards account lockout
        //        // To enable password failures to trigger account lockout, set lockoutOnFailure: true
        //        var result = await this.signInManager.PasswordSignInAsync(model.UserName, model.Password, true, lockoutOnFailure: false);
        //        if (result.Succeeded)
        //        {
        //            return this.Redirect("/Home/Index");
        //        }

        //        if (result.IsLockedOut)
        //        {
        //            return this.View("Lockout");
        //        }

        //        this.ModelState.AddModelError(String.Empty, "Invalid login attempt.");
        //        return this.View(model);
        //    }

        //    // If we got this far, something failed, redisplay form
        //    return this.View(model);
        //}

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                this.ModelState.AddModelError(String.Empty, error.Description);
            }
        }

        private IActionResult RedirectToLocal(String returnUrl)
        {
            if (this.Url.IsLocalUrl(returnUrl))
            {
                return this.Redirect(returnUrl);
            }
            else
            {
                return this.Redirect("/");
            }
        }

        #endregion
    }
}
