using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Backend5.Models;
using Backend5.Data;
using Backend5.Models.ManageViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Backend5.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ILogger logger;
        private readonly ApplicationDbContext _context;

        public ManageController(
          ApplicationDbContext context,
          UserManager<ApplicationUser> userManager,
          SignInManager<ApplicationUser> signInManager,
          ILoggerFactory loggerFactory)
        {
            this._context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = loggerFactory.CreateLogger<ManageController>();
        }

        //
        // GET: /Manage/Index
        [HttpGet]
        public async Task<IActionResult> Index(ManageMessageId? message = null)
        {
            var applicationDbContext = _context.Cards
                .Include(f => f.ApplicationUser);

            this.ViewData["StatusMessage"] =
                message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
                : message == ManageMessageId.Error ? "An error has occurred."
                : "";

            var user = await this.GetCurrentUserAsync();
            if (user == null)
            {
                return this.View("Error");
            }

            return this.View(await applicationDbContext.ToListAsync());
        }

        // GET: /Manage/ChangePassword
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return this.View();
        }

        // POST: /Manage/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var user = await this.GetCurrentUserAsync();
            if (user != null)
            {
                var result = await this.userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                if (result.Succeeded)
                {
                    await this.signInManager.SignInAsync(user, isPersistent: false);
                    this.logger.LogInformation(3, "User changed their password successfully.");
                    return this.RedirectToAction(nameof(ManageController.Index), new { Message = ManageMessageId.ChangePasswordSuccess });
                }

                this.AddErrors(result);
                return this.View(model);
            }

            return this.RedirectToAction(nameof(ManageController.Index), new { Message = ManageMessageId.Error });
        }


        // GET: /Manage/ChangeName
        [HttpGet]
        public IActionResult ChangeName(String nameId)
        {
            this.ViewBag.ChangeNameId = nameId;
            return this.View();
        }

        // POST: /Manage/ChangeName
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeName(ChangeNameViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var user = await this.GetCurrentUserAsync();
            if (user != null)
            {
                var result = await this.userManager.ChangePasswordAsync(user, model.OldName, model.NewName);
                if (result.Succeeded)
                {
                    await this.signInManager.SignInAsync(user, isPersistent: false);
                    
                    return this.RedirectToAction(nameof(ManageController.Index), new { Message = ManageMessageId.ChangePasswordSuccess });
                }

                this.AddErrors(result);
                return this.View(model);
            }

            return this.RedirectToAction(nameof(ManageController.Index), new { Message = ManageMessageId.Error });
        }

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                this.ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            Error
        }

        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return this.userManager.GetUserAsync(this.HttpContext.User);
        }

        #endregion
    }
}
