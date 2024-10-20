using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TicketSystem.Data;
using TicketSystem.Models;

namespace TicketSystem.Controllers
{
    public class JourneyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JourneyController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet]
        public IActionResult AddJourney()
        {
            List<Train> trains = _context.Trains.ToList();
            ViewBag.Trains = new SelectList(_context.Trains.ToList(), "Id","Route");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddJourney(Journey journey)
        {
            
            _context.Journeys.Add(journey);
            await _context.SaveChangesAsync();
            return RedirectToAction("GetAllJourney");
            
            
            
        }
        [HttpGet]
        public async Task<IActionResult> GetAllJourney()
        {
            var journey = await _context.Journeys.ToListAsync();
            return View(journey);
        }
    }
}
