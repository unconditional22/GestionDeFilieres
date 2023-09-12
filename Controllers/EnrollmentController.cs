using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using EnrollmentManagement.Models;

namespace EnrollmentManagement.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly IEnrollmentRepository _enrollmentRepository;

        public EnrollmentController(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        // Sample data (you can replace this with your database logic)
        private static List<Enrollment> enrollments = new List<Enrollment>
        {
            new Enrollment { Id = 1, StudentId = 1, CourseId = 1, EnrollmentDate = DateTime.Now, StatusE = "Active" },
            new Enrollment { Id = 2, StudentId = 2, CourseId = 2, EnrollmentDate = DateTime.Now, StatusE = "Complete" }
        };

        public IActionResult Index()
        {
            var enrollments = _enrollmentRepository.GetAllEnrollments();
            return View(enrollments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                _enrollmentRepository.AddEnrollment(enrollment);
                return RedirectToAction("Index");
            }

            // Debugging code to log model validation errors
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine($"Model error: {error.ErrorMessage}");
            }

            return View(enrollment);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var enrollment = _enrollmentRepository.GetEnrollmentById(id);

            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        [HttpPost]
        public IActionResult Edit(Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                _enrollmentRepository.UpdateEnrollment(enrollment);
                return RedirectToAction("Index");
            }

            return View(enrollment);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var enrollment = _enrollmentRepository.GetEnrollmentById(id);

            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var enrollment = _enrollmentRepository.GetEnrollmentById(id);

            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            _enrollmentRepository.DeleteEnrollment(id);
            return RedirectToAction("Index");
        }
    }
}
