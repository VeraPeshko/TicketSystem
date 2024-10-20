namespace TicketSystem.Models
{
    public class Journey
    {
        public int Id { get; set; }
        public int TrainId { get; set; }
        public Train Train { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
    }
}
