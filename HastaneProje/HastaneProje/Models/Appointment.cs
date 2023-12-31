using HastaneProje.Areas.Identity.Data;
using System.Security.Principal;

namespace HastaneProje.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime AppointmentDateTime { get; set; }
        public string Status { get; set; } 

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public string UserId { get; set; }
        public HastaneUser User { get; set; }
    }
}
