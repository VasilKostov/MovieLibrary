using MovieLibrary.Models;
using MovieLibrary.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using MovieLibrary.Data;
using MovieLibrary.Models.Movies;

namespace MovieLibrary.Controllers
{
    //Change the functions which are needed to be authorized to use it to make them [Auth..]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ApplicationDbContext _db;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _signInManager = signInManager;
            _userManager = userManager;
            _db = db;
        }

        [HttpGet]
        public IActionResult Profile()
        {
            AppUser? user = _db.Users.FirstOrDefault(u => u.UserName == User.Identity!.Name);

            if (user is null)
                return View("Error", "Nullable exception");

            var comments = _db.MovieComments.Where(c => c.AppUserId == user.Id).ToList();
            var createdMovies = _db.Movies.Where(m => m.AppUserId == user.Id && m.Accepted == true).ToList();
            var model = new ProfilePageViewModel()
            {
                Username = user.UserName,
                Email = user.Email,
                Age = user.Age,
                ProfileImageUrl = user.PictureSource!,
                Comments = comments,
                CreatedMovies = createdMovies,
                CurrentPassword = user.PasswordHash
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            LoginViewModel loginViewModel = new LoginViewModel();
            loginViewModel.ReturnUrl = returnUrl ?? Url.Content("~/");
            return View(loginViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(loginViewModel.Email);

                if (user is null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(loginViewModel);
                }
                else
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, loginViewModel.RememberMe, lockoutOnFailure: true);

                    if (result.Succeeded)
                        return RedirectToAction("Index", "Home");
                    else if (result.IsLockedOut)
                        return View("Lockout");
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                        return View(loginViewModel);
                    }
                }
            }

            return View(loginViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public async Task<IActionResult> Register(string? returnUrl = null)
        {
            var registerViewModel = new RegisterViewModel();
            registerViewModel.ReturnUrl = returnUrl;
            return View(registerViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel, string? returnUrl = null)
        {
            registerViewModel.ReturnUrl = returnUrl;
            returnUrl = returnUrl ?? Url.Content("~/");
            var doesEmailExist = _db.AppUser.Any(x => x.Email == registerViewModel.Email);
            var doesUsernameExist = _db.AppUser.Any(x => x.UserName == registerViewModel.UserName);

            if (doesEmailExist)
                ModelState.AddModelError(nameof(registerViewModel.Email), "The email already exists.");

            if (doesUsernameExist)
                ModelState.AddModelError(nameof(registerViewModel.UserName), "The username already exists.");                

            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    Email = registerViewModel.Email,
                    UserName = registerViewModel.UserName,
                    FirstName = registerViewModel.FirstName,
                    LastName = registerViewModel.LastName,
                    Age = registerViewModel.Age
                };

                //if there is no picture uploaded, we set the default one
                if (registerViewModel.ProfilePircture is null)
                {
                    var path = Path.Combine(_webHostEnvironment.WebRootPath, "images/profilePictures/emptyProfilePicture.png");
                    user.PictureSource = ChangePicturePath(path);
                }
                else if (registerViewModel.ProfilePircture.Length > 0 && registerViewModel.ProfilePircture != null)
                {
                    var path = Path.Combine(_webHostEnvironment.WebRootPath, "images/profilePictures", registerViewModel.ProfilePircture.FileName);
                    using (var memoryStream = new MemoryStream())
                    {
                        await registerViewModel.ProfilePircture.CopyToAsync(memoryStream);

                        // Upload the file if less than or equals 5 MB  
                        if (memoryStream.Length < 5 * 1024 * 1024)
                            user.PictureSource = ChangePicturePath(path);
                        else
                        {
                            ModelState.AddModelError(nameof(registerViewModel.ProfilePircture), "The file is too large. It must be under 5 MB");
                            return View(registerViewModel);
                        }
                    }

                    using FileStream stream = new FileStream(path, FileMode.Create);
                    await registerViewModel.ProfilePircture.CopyToAsync(stream);
                    stream.Close();
                }

                var result = await _userManager.CreateAsync(user, registerViewModel.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "User");
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }

                ModelState.AddModelError("Password", "User could not be created. Password not unique enough");
            }

            return View(registerViewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExternalLoginConfirmation(ExternalLoginViewModel model, string? returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            var isEmailAlreadyExists = _db.AppUser.Any(x => x.Email == model.Email);
            var isUsernameAlreadyExists = _db.AppUser.Any(x => x.UserName == model.Username);
            if (isEmailAlreadyExists)
            {
                ModelState.AddModelError(nameof(model.Email), "The email already exists.");
            }
            if (isUsernameAlreadyExists)
            {
                ModelState.AddModelError(nameof(model.Username), "The username already exists.");
            }
            if (ModelState.IsValid)
            {
                //get the info about the user from external login provider
                var info = await _signInManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("Error");
                }
                var user = new AppUser
                {
                    UserName = model.Username,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Age = model.Age,
                };

                if (model.ProfilePircture == null)
                {
                    var path = Path.Combine(_webHostEnvironment.WebRootPath, "images/profilePictures/emptyProfilePicture.png");
                    user.PictureSource = ChangePicturePath(path);
                }

                else if (model.ProfilePircture.Length > 0 && model.ProfilePircture != null)
                {
                    var path = Path.Combine(_webHostEnvironment.WebRootPath, "images/profilePictures", model.ProfilePircture.FileName);
                    using (var memoryStream = new MemoryStream())
                    {
                        await model.ProfilePircture.CopyToAsync(memoryStream);

                        // Upload the file if less than or equals 5 MB  
                        if (memoryStream.Length < 5 * 1024 * 1024)
                        {
                            user.PictureSource = ChangePicturePath(path);
                        }
                        else
                        {
                            ModelState.AddModelError(nameof(model.ProfilePircture), "The file is too large. It must be under 5 MB");
                            return View(model);
                        }
                    }
                    using FileStream stream = new FileStream(path, FileMode.Create);
                    await model.ProfilePircture.CopyToAsync(stream);
                    stream.Close();
                }

                var result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "User");
                    result = await _userManager.AddLoginAsync(user, info);
                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        await _signInManager.UpdateExternalAuthenticationTokensAsync(info);
                        return LocalRedirect(returnUrl);
                    }
                }
                ModelState.AddModelError("Email", "Error occured");
            }
            ViewData["ReturnUrl"] = returnUrl;
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> ExternalLoginCallback(string? returnurl = null, string? remoteError = null)
        {
            if (remoteError != null)
            {
                ModelState.AddModelError(string.Empty, $"Error from external provider: {remoteError}");
                return View(nameof(Login));
            }
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                return RedirectToAction(nameof(Login));
            }

            //Sign in the user with this external login provider, if the user already has a login.
            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false);
            if (result.Succeeded)
            {
                //update any authentication tokens
                await _signInManager.UpdateExternalAuthenticationTokensAsync(info);
                returnurl = returnurl ?? Url.Content("~/");
                return LocalRedirect(returnurl);
            }
            else
            {
                //If the user does not have account, then we will ask the user to create an account.
                ViewData["ReturnUrl"] = returnurl;
                ViewData["ProviderDisplayName"] = info.ProviderDisplayName;
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);
                var firstName = info.Principal.FindFirstValue(ClaimTypes.GivenName);
                var lastName = info.Principal.FindFirstValue(ClaimTypes.Surname);
                return View("ExternalLoginConfirmation", new ExternalLoginViewModel
                {
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName
                });
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult ExternalLogin(string provider, string? returnurl = null)
        {
            //request a redirect to the external login provider
            var redirecturl = Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnurl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirecturl);
            return Challenge(properties, provider);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeProfilePicture(ProfilePageViewModel model)
        {
            AppUser? user = _db.Users.FirstOrDefault(u => u.UserName == User.Identity!.Name);

            if (user is null)
                return View("Error", "Nullable exception");

            if (model.NewProfilePicture == null)
            {
                var path = Path.Combine(_webHostEnvironment.WebRootPath, "images/profilePictures/emptyProfilePicture.png");
                user.PictureSource = ChangePicturePath(path);
            }
            else if (model.NewProfilePicture.Length > 0 && model.NewProfilePicture != null)
            {
                var path = Path.Combine(_webHostEnvironment.WebRootPath, "images/profilePictures", model.NewProfilePicture.FileName);
                using (var memoryStream = new MemoryStream())
                {
                    await model.NewProfilePicture.CopyToAsync(memoryStream);

                    // Upload the file if less than 5 MB  
                    if (memoryStream.Length < 5 * 1024 * 1024)
                    {
                        user.PictureSource = ChangePicturePath(path);
                    }
                    else
                    {
                        //ModelState.AddModelError(nameof(model.NewProfilePicture), "The file is too large. It must be under 5 MB");
                        //return View(nameof(Profile));
                    }
                }
                using FileStream stream = new FileStream(path, FileMode.Create);
                await model.NewProfilePicture.CopyToAsync(stream);
                stream.Close();
            }
            _db.SaveChanges();
            return RedirectToAction(nameof(Profile));
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ProfilePageViewModel model)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login");
            }
            var result = await _userManager.ChangePasswordAsync(user,model.CurrentPassword, model.NewPassword);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return RedirectToAction(nameof(Profile));
            }

            await _signInManager.RefreshSignInAsync(user);
            return RedirectToAction(nameof(Profile));
        }

        private string ChangePicturePath(string path)
        {
            List<string> changedPathList = path.Split('\\').ToList();
            if (changedPathList.Last().Contains("emptyProfilePicture"))
            {
                return path = "~/" + changedPathList.Last();
            }
            else
            {
                return path = "~/" + changedPathList[changedPathList.Count - 2] + "/" + changedPathList[changedPathList.Count - 1];
            }
        }
    }
}