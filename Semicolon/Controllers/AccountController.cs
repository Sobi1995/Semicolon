using Application.Common.Dtos;
using Application.Common.Interfaces;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Octokit;
using Octokit.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Route("[controller]/[action]")]
    public class AccountController : BaseController
    {
        private readonly IIdentityService _identityService;
      
        private readonly ILogger<ContactController> _logger;


        public AccountController(ILogger<ContactController> logger, IIdentityService  identityService)
        {

            _logger = logger;
            _identityService = identityService;
        }
        public async Task<IActionResult> Login() => View();

        [HttpGet]
        public IActionResult SignIn(string returnUrl = "/")
        {
            return Challenge(new AuthenticationProperties() { RedirectUri = returnUrl });
        }

        [HttpGet]
        public async Task<IActionResult> ResponseGitHub()
        {

             if (User.Identity.IsAuthenticated)
            {
                var userName = User.FindFirst(c => c.Type == "urn:github:login")?.Value;
                var gitHubClient = new GitHubClient(new ProductHeaderValue("Semecolon"));
                var user = await gitHubClient.User.Get(userName);

                if (!await _identityService.IsUserExistAsync(userName))
                {
                    await _identityService.CreateUserAsync(new CreateAccountWithGitHubDto(){
                        Avatar_url=user.AvatarUrl,
                        Email=user.Email,
                        Id=user.Id,
                        UserName=userName,
                        Bio=user.Bio
                
                });
                }
                return RedirectToAction("",  userName);
            }
            return View();
        }
        public async Task<IActionResult> SignOut()
        {
      
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("", "");
        }


    }
}