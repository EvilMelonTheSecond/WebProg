using HastaneProje.Areas.Identity.Data;
using HastaneProje.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HastaneProje.Controllers
{
    [Authorize]

    public class AppointmentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AppointmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult ViewAvailableAppointments(int doctorId)
        {
            // Retrieve the doctor and available appointments
            var doctor = _context.Doctors.Include(d => d.Appointments).FirstOrDefault(d => d.Id == doctorId);
            var availableAppointments = doctor?.GetAvailableAppointments(DateTime.Now, DateTime.Now.AddDays(7));

            // Pass the data to the view
            return View(new AvailableAppointmentsViewModel
            {
                Doctor = doctor,
                AvailableAppointments = availableAppointments
            });
        }

        [HttpPost]
        public IActionResult ScheduleAppointment(int doctorId, DateTime appointmentDateTime)
        {
            // Create a new appointment
            var appointment = new Appointment
            {
                DoctorId = doctorId,
                AppointmentDateTime = appointmentDateTime,
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier), // Get the user's ID
                Status = "Scheduled" // You can set the initial status here
            };

            // Save the appointment to the database
            _context.Appointments.Add(appointment);
            _context.SaveChanges();

            return RedirectToAction("ViewUserAppointments");
        }
        [Authorize]

        public IActionResult ViewUserAppointments()
        {
            // Retrieve the user's appointments
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userAppointments = _context.Appointments
                .Include(a => a.Doctor)
                .Where(a => a.UserId == userId)
                .OrderBy(a => a.AppointmentDateTime)
                .ToList();

            // Pass the data to the view
            return View(userAppointments);
        }
    }

}
