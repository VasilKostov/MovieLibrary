using MovieLibrary.Models;
using MovieLibrary.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using MovieLibrary.Data;
using MovieLibrary.Models.Movies;
using MovieLibrary.Contracts;
using MovieLibrary.Singleton;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MovieLibrary.Controllers
{
    public class AccountController : BaseController
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly ApplicationDbContext _db;
        private readonly IAccountService AService;
        private readonly IMovieService MService;

        public AccountController(UserManager<AppUser> appUserManager, SignInManager<AppUser> signManager, ApplicationDbContext db, IWebHostEnvironment hostEnvironment, IAccountService accountService, IMovieService movieService)
        {
            webHostEnvironment = hostEnvironment;
            userManager = appUserManager;
            signInManager = signManager;
            AService = accountService;
            MService = movieService;
            _db = db;
        }

        #region Profile
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var user = await MService.GetUserById(GetUserId());

            if (user is null)
                return RedirectToAction("Error", "Error", new ErrorModel { ErrorCode = (int)ErrorCode.NullUser });

            var (comments, createdMovies) = await AService.GetProfileInfo(user.Id);

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
        #endregion

        #region UsersList

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UsersList()
        {
            return View(await AService.GetUsersList());
        }
        #endregion

        #region EditUser
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(string userId)
        {
            var user = await MService.GetUserById(userId);

            if (user is null)
                return RedirectToAction("Error", "Error", new ErrorModel { ErrorCode = (int)ErrorCode.NullUser });

            user = await AService.SetUserRole(user);

            return View(user);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AppUser user)
        {
            if (ModelState.IsValid)
            {
                var userDbValue = await MService.GetUserById(user.Id);

                if (userDbValue is null)
                    return RedirectToAction("Error", "Error", new ErrorModel { ErrorCode = (int)ErrorCode.NullUser });

                var userRole = await AService.GetUserRole(userDbValue.Id);

                if (userRole is not null)
                {
                    var previousRoleName = await AService.GetCurrentUserRole(userRole);
                    await userManager.RemoveFromRoleAsync(userDbValue, previousRoleName);
                }

                var roleName = await AService.GetCurrentUserRole(user);

                await userManager.AddToRoleAsync(userDbValue, roleName);

                await _db.SaveChangesAsync();

                return RedirectToAction("UsersList");
            }

            user = await AService.SetUserRole(user);

            return View(user);
        }
        #endregion

        #region DeleteUser
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string userId)
        {
            var user = await MService.GetUserById(userId);

            if (user is null)
                return RedirectToAction("Error", "Error", new ErrorModel { ErrorCode = (int)ErrorCode.NullUser });

            await AService.DeleteUser(user);

            return RedirectToAction("UsersList");
        }
        #endregion

        #region Login
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string? returnUrl = null)
        {
            var loginViewModel = new LoginViewModel();

            loginViewModel.ReturnUrl = returnUrl ?? Url.Content("~/");

            return View(loginViewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(loginViewModel.Email);

                if (user is null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(loginViewModel);
                }
                else
                {
                    var result = await signInManager.PasswordSignInAsync(user, loginViewModel.Password, loginViewModel.RememberMe, lockoutOnFailure: true);

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
        #endregion

        #region LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOff()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Login");
        }
        #endregion

        #region Register
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string? returnUrl = null)
        {
            var registerViewModel = new RegisterViewModel();

            registerViewModel.ReturnUrl = returnUrl;

            return View(registerViewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel, string? returnUrl = null)
        {
            registerViewModel.ReturnUrl = returnUrl;
            returnUrl = returnUrl ?? Url.Content("~/");

            if (await AService.EmailExists(registerViewModel.Email))
                ModelState.AddModelError(nameof(registerViewModel.Email), "The email already exists.");

            if (await AService.UsernameExists(registerViewModel.UserName))
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
                    var path = Path.Combine(webHostEnvironment.WebRootPath, "images/profilePictures/emptyProfilePicture.png");
                    user.PictureSource = ChangePicturePath(path);
                }
                else if (registerViewModel.ProfilePircture.Length > 0 && registerViewModel.ProfilePircture is not null)
                {
                    var path = Path.Combine(webHostEnvironment.WebRootPath, "images/profilePictures", registerViewModel.ProfilePircture.FileName);

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

                var result = await userManager.CreateAsync(user, registerViewModel.Password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "User");
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }

                ModelState.AddModelError("Password", "User could not be created. Password not unique enough");
            }

            return View(registerViewModel);
        }
        #endregion

        #region ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExternalLoginConfirmation(ExternalLoginViewModel model, string? returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (await AService.EmailExists(model.Email))
            {
                ModelState.AddModelError(nameof(model.Email), "The email already exists.");
            }
            if (await AService.UsernameExists(model.Username))
            {
                ModelState.AddModelError(nameof(model.Username), "The username already exists.");
            }
            if (ModelState.IsValid)
            {
                //Gets the info about the user from the external login provider
                var info = await signInManager.GetExternalLoginInfoAsync();

                if (info is null)
                    return RedirectToAction("Error", "Error", new ErrorModel { ErrorCode = (int)ErrorCode.NullExternalLoginInfo });

                var user = new AppUser
                {
                    UserName = model.Username,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Age = model.Age,
                };

                if (model.ProfilePircture is null)
                {
                    var path = Path.Combine(webHostEnvironment.WebRootPath, "images/profilePictures/emptyProfilePicture.png");
                    user.PictureSource = ChangePicturePath(path);
                }
                else if (model.ProfilePircture.Length > 0 && model.ProfilePircture is not null)
                {
                    var path = Path.Combine(webHostEnvironment.WebRootPath, "images/profilePictures", model.ProfilePircture.FileName);

                    using (var memoryStream = new MemoryStream())
                    {
                        await model.ProfilePircture.CopyToAsync(memoryStream);

                        if (memoryStream.Length < 5 * 1024 * 1024)//Upload the file if less than or equals 5 MB  
                            user.PictureSource = ChangePicturePath(path);
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

                var result = await userManager.CreateAsync(user);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "User");
                    result = await userManager.AddLoginAsync(user, info);
                    if (result.Succeeded)
                    {
                        await signInManager.SignInAsync(user, isPersistent: false);
                        await signInManager.UpdateExternalAuthenticationTokensAsync(info);
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
            if (remoteError is not null)
            {
                ModelState.AddModelError(string.Empty, $"Error from external provider: {remoteError}");
                return View(nameof(Login));
            }
            var info = await signInManager.GetExternalLoginInfoAsync();

            if (info is null)
                return RedirectToAction("Login");

            //Sign in the user with this external login provider, if the user already has a login.
            var result = await signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false);

            if (result.Succeeded)
            {
                //Update any authentication tokens
                await signInManager.UpdateExternalAuthenticationTokensAsync(info);
                returnurl = returnurl ?? Url.Content("~/");
                return LocalRedirect(returnurl);
            }
            else
            {
                //If the user does not have an account, then we will ask the user to create one.
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
            //Requests a redirect to the external login provider
            var redirecturl = Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnurl });
            var properties = signInManager.ConfigureExternalAuthenticationProperties(provider, redirecturl);

            return Challenge(properties, provider);
        }
        #endregion

        #region Search
        public async Task<IActionResult> Search(string? data)
        {
            var user = await MService.GetUserById(GetUserId());

            if (user is null)
                return RedirectToAction("Error", "Error", new ErrorModel { ErrorCode = (int)ErrorCode.NullUser });

            var users = await AService.GetSearchedUsers(data);
            return View("UsersList", users);
        }
        #endregion

        #region ChangeFuncs

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ChangeProfilePicture(ProfilePageViewModel? model)
        {
            var user = await MService.GetUserById(GetUserId());

            if (user is null)
                return RedirectToAction("Error", "Error", new ErrorModel { ErrorCode = (int)ErrorCode.NullUser });

            if (model is null)
                return RedirectToAction("Error", "Error", new ErrorModel { ErrorCode = (int)ErrorCode.NullParameter });

            if (model.NewProfilePicture is null)
            {
                var path = Path.Combine(webHostEnvironment.WebRootPath, "images/profilePictures/emptyProfilePicture.png");
                user.PictureSource = ChangePicturePath(path);
            }
            else if (model.NewProfilePicture.Length > 0 && model.NewProfilePicture is not null)
            {
                var path = Path.Combine(webHostEnvironment.WebRootPath, "images/profilePictures", model.NewProfilePicture.FileName);

                using (var memoryStream = new MemoryStream())
                {
                    await model.NewProfilePicture.CopyToAsync(memoryStream);

                    if (memoryStream.Length < 5 * 1024 * 1024)// Upload the file if less than 5 MB  
                        user.PictureSource = ChangePicturePath(path);
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
            await _db.SaveChangesAsync();
            return RedirectToAction("Profile");
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ChangePassword(ProfilePageViewModel? model)
        {
            var user = await MService.GetUserById(GetUserId());

            if (user is null)
                return RedirectToAction("Error", "Error", new ErrorModel { ErrorCode = (int)ErrorCode.NullUser });

            if (model is null)
                return RedirectToAction("Error", "Error", new ErrorModel { ErrorCode = (int)ErrorCode.NullParameter });

            var result = await userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);

                return RedirectToAction("Profile");
            }

            await signInManager.RefreshSignInAsync(user);
            return RedirectToAction("Profile");
        }
        #endregion

        #region OtherFuncs
        private string ChangePicturePath(string path)
        {
            var changedPathList = path.Split('\\').ToList();

            if (changedPathList.Last().Contains("emptyProfilePicture"))
                return "~/" + changedPathList.Last();
            else
                return "~/" + changedPathList[changedPathList.Count - 2] + "/" + changedPathList[changedPathList.Count - 1];
        }
        #endregion
    }
}