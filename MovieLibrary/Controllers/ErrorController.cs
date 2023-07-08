using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Models;
using MovieLibrary.Singleton;
using MovieLibrary.ViewModels;
using System.Diagnostics;

namespace MovieLibrary.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Error(ErrorModel error)
        {
            ErrorCodes.Messages.TryGetValue(error.ErrorCode, out var message);

            var errorViewModel = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                ErrorCode = error.ErrorCode
            };

            if (!string.IsNullOrEmpty(error.ErrorMessage))
                errorViewModel.ErrorMessage = error.ErrorMessage ?? "ERROR: UNPARSABLE ERROR";
            else
                errorViewModel.ErrorMessage = message ?? "ERROR: UNPARSABLE ERROR";

            return View(errorViewModel);
        }
    }
}
