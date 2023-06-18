using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MovieLibrary.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        protected string GetUserId()
        {
            string id = string.Empty;

            if (User is not null)
            {
                id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }

            return id;
        }
    }
}
