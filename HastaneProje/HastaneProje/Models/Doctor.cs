using System.ComponentModel.DataAnnotations.Schema;

namespace HastaneProje.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public ICollection<Appointment> Appointments { get; set; }

        public int MainBranchId { get; set; }
        public Branch MainBranch { get; set; }

        public int PolyclinicBranchId { get; set; }
        public Branch PolyclinicBranch { get; set; }
        [NotMapped]
        public List<DayOfWeek> AvailableDays { get; set; }

        [NotMapped]
        public Dictionary<DayOfWeek, List<TimeSpan>> AvailableTimeSlots { get; set; }
        public List<DateTime> GetAvailableAppointments(DateTime startDate, DateTime endDate)
        {
            var availableAppointments = new List<DateTime>();

            // Your logic for determining available appointments based on AvailableTimeSlots

            return availableAppointments;
        }
    }
}
