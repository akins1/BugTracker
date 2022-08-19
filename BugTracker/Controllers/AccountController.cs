using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;

namespace BugTracker.Controllers
{
    public class AccountController : Controller
    {
        

        public async Task Login(string returnUrl = "/home/dashboard")
        {
            
            var authProperties = new LoginAuthenticationPropertiesBuilder()
                .WithRedirectUri(returnUrl)
                .Build();

            await HttpContext.ChallengeAsync(Auth0Constants.AuthenticationScheme, authProperties);
            //Console.WriteLine("After Challenge Async: " + User.Identity.IsAuthenticated);
            /*var client = new AuthenticationApiClient("akins1.us.auth0.com");

            var authorizationUrl = client.BuildAuthorizationUrl()
              .WithResponseType(AuthorizationResponseType.Code)
              .WithClient("l3568raHXqiBhbzWG75ixW7YBMSXFx7c")
              .WithConnection("google-oauth2")
              .WithRedirectUrl("https://localhost:7149/callback")
              .WithScope("openid offline_access")
              .Build();

            return Redirect(authorizationUrl.ToString());*/

        }

        [Authorize]
        public async Task Logout()
        {
            var logoutProperties = new LogoutAuthenticationPropertiesBuilder()
                .WithRedirectUri(Url.Action("Index", "Home"))
                .Build();

            await HttpContext.SignOutAsync(Auth0Constants.AuthenticationScheme, logoutProperties);

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        [Authorize]
        [HttpGet("profile/test")]
        public IActionResult Profile()
        {

        return View();

        }
    }
}
