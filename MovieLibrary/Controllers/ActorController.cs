using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieLibrary.Contracts;
using MovieLibrary.Data;
using MovieLibrary.Models;
using MovieLibrary.Models.Actors;
using MovieLibrary.Models.Relations;
using MovieLibrary.Services;
using MovieLibrary.Singleton;
using MovieLibrary.ViewModels;
using MovieLibrary.ViewModels.ActorViewModels;

namespace MovieLibrary.Controllers
{
    public class ActorController : BaseController
    {
        private readonly IMovieService MService;
        public ActorController(IMovieService movieService)
        {
            MService = movieService;
        }

        #region CreateActor
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new CreateActorViewModel();

            var actorAwards = await MService.GetActorAwards();

            model.AllActorAwards = new SelectList(actorAwards, "Id", "Name").ToList();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateActorViewModel? model)
        {
            var user = await MService.GetUserById(GetUserId());

            if (user is null)
                return RedirectToAction("Error", "Error", new ErrorModel { ErrorCode = (int)ErrorCode.NullUser });

            if (model is null)
                return RedirectToAction("Error", "Error", new ErrorModel { ErrorCode = (int)ErrorCode.NullParameter });
            
            if (ModelState.IsValid)
            {
                var newActor = new Actor()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Gender = model.Gender,
                    AppUserId = user.Id,
                };

                await MService.CreateActor(newActor);
                await MService.AddActorAwards(model.SelectedActorAwardsIds, newActor);

                return RedirectToAction("Create");
            }

            var actorAwards = await MService.GetActorAwards();

            model.AllActorAwards = new SelectList(actorAwards, "Id", "Name").ToList();
            
            return View(model);
        }
        #endregion
    }
}
