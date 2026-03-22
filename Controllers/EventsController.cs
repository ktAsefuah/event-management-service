using System.Linq;
using EventManager.Data;
using EventManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventManager.Controllers
{
    [Authorize]
    public class EventsController : Controller
    {
        private readonly AppDbContext _db;

        public EventsController(AppDbContext db)
        {
            _db = db;
        }

        // GET: /Events
        [AllowAnonymous]
        public IActionResult Index()
        {
            var events = _db.Events.ToList().OrderBy(e => e.Date).ThenBy(e => e.Time).ToList();
            return View(events);
        }

        // GET: /Events/Details/5
        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            var ev = _db.Events.Find(id);
            if (ev == null) return NotFound();
            return View(ev);
        }

        // GET: /Events/Create
        public IActionResult Create() => View();

        // POST: /Events/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Event ev)
        {
            if (!ModelState.IsValid) return View(ev);

            ev.CreatedBy = User.Identity?.Name ?? "anonymous";
            _db.Events.Add(ev);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: /Events/Edit/5
        public IActionResult Edit(int id)
        {
            var ev = _db.Events.Find(id);
            if (ev == null) return NotFound();
            return View(ev);
        }

        // POST: /Events/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Event ev)
        {
            if (id != ev.Id) return BadRequest();
            if (!ModelState.IsValid) return View(ev);

            var existing = _db.Events.Find(id);
            if (existing == null) return NotFound();

            existing.Title = ev.Title;
            existing.Description = ev.Description;
            existing.Date = ev.Date;
            existing.Time = ev.Time;
            existing.Location = ev.Location;

            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: /Events/Delete/5
        public IActionResult Delete(int id)
        {
            var ev = _db.Events.Find(id);
            if (ev == null) return NotFound();
            return View(ev);
        }

        // POST: /Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var ev = _db.Events.Find(id);
            if (ev != null)
            {
                _db.Events.Remove(ev);
                _db.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}