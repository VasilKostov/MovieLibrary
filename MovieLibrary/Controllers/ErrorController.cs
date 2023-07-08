using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Models;
using MovieLibrary.Singleton;
using MovieLibrary.ViewModels;
using System.Diagnostics;

namespace MovieLibrary.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Error(int errorCode)
        {
            ErrorCodes.Messages.TryGetValue(errorCode, out var message);

            var errorViewModel = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                ErrorCode = errorCode,
                ErrorMessage = message ?? "ERROR: UNPARSABLE ERROR"
            };

            return View(errorViewModel);
        }

        public IActionResult Error(int errorCode, string errorMessage)
        {
            ErrorCodes.Messages.TryGetValue(errorCode, out var _);

            var errorViewModel = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                ErrorCode = errorCode,
                ErrorMessage = errorMessage ?? "ERROR: UNPARSABLE ERROR"
            };

            return View(errorViewModel);
        }
    }
}
