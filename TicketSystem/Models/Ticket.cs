namespace TicketSystem.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int JourneyId { get; set; }
        public Journey Journey { get; set; }
        public string PassengerId { get; set; }
        public Passenger Passenger { get; set; }
        public decimal Price { get; set; }
    }
}
