using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketSystem.Data;
using TicketSystem.Models;

namespace TicketSystem.Controllers
{
    public class TrainController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrainController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet]
        public IActionResult AddTrain()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTrain(Train train)
        {
            if (ModelState.IsValid)
            {
                _context.Trains.Add(train);
                await _context.SaveChangesAsync();
                return RedirectToAction("GetAllTrains");
            }
            return View(train);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTrains()
        {
            var trains = await _context.Trains.ToListAsync();
            return View(trains);
        }
    }
}
