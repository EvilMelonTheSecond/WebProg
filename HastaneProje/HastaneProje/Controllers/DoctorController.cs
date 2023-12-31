using HastaneProje.Areas.Identity.Data;
using HastaneProje.Models;
using Microsoft.AspNetCore.Mvc;

namespace HastaneProje.Controllers
{
    public class DoctorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DoctorController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var doctors = _context.Doctors.ToList();
            return View(doctors);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DoctorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var doctor = new Doctor
                {
                    Name = model.Name,
                    Specialization = model.Specialization,
                    MainBranchId = model.MainBranchId,
                    PolyclinicBranchId = model.PolyclinicBranchId
                };

                _context.Doctors.Add(doctor);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }
        public IActionResult OpenBranch()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult OpenBranch(BranchViewModel model)
        {
            if (ModelState.IsValid)
            {
                var branch = new Branch
                {
                    Name = model.Name,
                };

                _context.Branches.Add(branch);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
