using eTicket.Data.services;
using eTicket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace eTicket.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsServices _service;

        public ActorsController(IActorsServices service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        //Get: Actor/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName, ProfilePictureURL, Bio")] Actor actor)
        {
            //if (!ModelState.IsValid) return View(actor);

            await _service.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }

        //Get: Actors/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var actorDetail = await _service.GetByIdAsync(id);

            if (actorDetail == null) return View("NotFound");
            return View(actorDetail);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var actorDetail = await _service.GetByIdAsync(id);

            if (actorDetail == null) return View("NotFound");
            return View(actorDetail);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, FullName, ProfilePictureURL, Bio")] Actor actor)
        {
            await _service.UpdateAsync(id, actor);
            return RedirectToAction(nameof(Index));
        }

        //Get: Actors/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var actorDetail = await _service.GetByIdAsync(id);

            if (actorDetail == null) return View("NotFound");

            return View(actorDetail);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetail = await _service.GetByIdAsync(id);

            if (actorDetail == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
