using Microsoft.AspNetCore.Mvc;
using CourseManagementSystem.Data;
using CourseManagement.Models;
using StudentManagement.Models;
using EnrollmentManagement.Models;

namespace CourseManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            int studentCount = _context.Students.Count();
            int courseCount = _context.Courses.Count();
            int enrollmentCount = _context.Enrollments.Count();

            ViewBag.StudentCount = studentCount;
            ViewBag.CourseCount = courseCount;
            ViewBag.EnrollmentCount = enrollmentCount;

            return View();
        }
    }
}