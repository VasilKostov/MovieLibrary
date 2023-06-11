using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieLibrary.Data;
using MovieLibrary.Models;
using MovieLibrary.Models.Actors;
using MovieLibrary.Models.Relations;
using MovieLibrary.ViewModels.ActorViewModels;

namespace MovieLibrary.Controllers
{
    public class ActorController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ActorController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region CreateActor
        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreateActorViewModel();

            var actorAwards = _db.ActorAwards.ToList();

            model.AllActorAwards = new SelectList(actorAwards, "Id", "Name");

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateActorViewModel model)
        {
            var user = _db.Users.FirstOrDefault(u => u.UserName == User.Identity!.Name);

            if (user is null)
                return View("Error", "Nullable exception in AppUsers");

            var newActor = new Actor()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Gender = model.Gender,
                AppUserId = user.Id,
            };

            _db.Actors.Add(newActor);
            _db.SaveChanges();

            foreach (var awardId in model.SelectedActorAwardsIds)
            {
                var newActorWithAwards = new Actor_ActorAward()
                {
                    ActorId = newActor.Id,
                    ActorAwardId = awardId
                };

                _db.Actor_ActorAwards.Add(newActorWithAwards);
                _db.SaveChanges();
            }

            return RedirectToAction(nameof(Create));
        }
        #endregion
    }
}
