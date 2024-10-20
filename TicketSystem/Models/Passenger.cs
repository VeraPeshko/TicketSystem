using Microsoft.AspNetCore.Identity;

namespace TicketSystem.Models
{
    public class Passenger:IdentityUser
    {
        public string? FullName { get; set; }
        public DateTime? BirthDate { get; set; }
        
    }
}
