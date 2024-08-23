namespace Event_Management_API.Models
{
    public class Registration
    {
        public int Id { get; set; }  
        public DateTime RegistrationDate { get; set; }  
        public int EventId { get; set; }
        public Event Event { get; set; }
        public int AttendeeId { get; set; }
        public Attendee Attendee { get; set; }
    }

}
