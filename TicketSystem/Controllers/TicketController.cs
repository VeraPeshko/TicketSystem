using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketSystem.Data;
using TicketSystem.Models;

namespace TicketSystem.Controllers
{
    public class TicketController : Controller
    {
        private readonly ApplicationDbContext _context;


        public TicketController(ApplicationDbContext context)
        {
            _context = context;

        }
        [HttpPost]
        public async Task<IActionResult> BuyTicket(int journeyId, string passengerId, decimal price)
        {
            var journey = await _context.Journeys.FindAsync(journeyId);
            var passenger = await _context.Users.FindAsync(passengerId);

            if (journey == null || passenger == null)
            {
                return NotFound("Journey or Passenger not found.");
            }

            var ticket = new Ticket
            {
                JourneyId = journeyId,
                PassengerId = passengerId,
                Price = price,
                Journey = journey,
                Passenger = passenger
            };

            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();

            return View(ticket);
        }
        [Authorize]

        public async Task<IActionResult> ViewTickets(string passengerId)
        {
            var tickets = await _context.Tickets
                .Include(t => t.Journey)
                .Include(t => t.Passenger)
                .Where(t => t.PassengerId == passengerId)
                .ToListAsync();

            return View(tickets);
        }
        [Authorize]
        [HttpGet]
        public IActionResult BuyTicketForm()
        {
            return View();
        }

       
    }
}
