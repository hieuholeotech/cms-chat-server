using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cms.Model.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Cms.WebApplication.API.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ILogger<LogoutModel> _logger;

        public LogoutModel(SignInManager<AppUser> signInManager, ILogger<LogoutModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        public async Task<IActionResult> OnGet(string returnUrl = null, string logoutId = null)
        {
            await _signInManager.SignOutAsync();

            _logger.LogInformation("User logged out.");
            if (logoutId != null)
            {
                return Redirect("http://localhost:3000");
            }
            else
            {
                if (returnUrl != null)
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToPage();
                }
            }
        }

        public async Task<IActionResult> OnPost(string returnUrl = null, string logoutId = null)
        {
            
            await _signInManager.SignOutAsync();

            _logger.LogInformation("User logged out.");
            if (logoutId != null)
            {
                return Redirect("http://localhost:3000");
            } else
            {
                if (returnUrl != null)
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToPage();
                }
            }
            
        }
    }
}
