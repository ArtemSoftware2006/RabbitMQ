namespace service.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string PassangerName { get; set; } = "";
        public string PasportNb { get; set; } = "";
        public string From { get; set; } = "";
        public string To { get; set; } = "";
        public string Status { get; set; } = "";
    }
}