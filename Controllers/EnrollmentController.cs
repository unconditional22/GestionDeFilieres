using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using EnrollmentManagement.Models;

namespace EnrollmentManagement.Controllers
{
    public class EnrollmentController : Controller
    {
        // Sample data (you can replace this with your database logic)
        private static List<Enrollment> enrollments = new List<Enrollment>
        {
            new Enrollment { Id = 1, StudentId = 1, CourseId = 1, EnrollmentDate = DateTime.Now, StatusE = "Active" },
            new Enrollment { Id = 2, StudentId = 2, CourseId = 2, EnrollmentDate = DateTime.Now, StatusE = "Complete" }
        };

        public IActionResult Index()
        {
            // Display a list of enrollments
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
                // Add the new enrollment to the list (you can replace this with your database logic)
                enrollment.Id = enrollments.Max(e => e.Id) + 1;
                enrollments.Add(enrollment);

                return RedirectToAction("Index");
            }

            return View(enrollment);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var enrollment = enrollments.FirstOrDefault(e => e.Id == id);

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
                var existingEnrollment = enrollments.FirstOrDefault(e => e.Id == enrollment.Id);

                if (existingEnrollment == null)
                {
                    return NotFound();
                }

                existingEnrollment.StudentId = enrollment.StudentId;
                existingEnrollment.CourseId = enrollment.CourseId;
                existingEnrollment.EnrollmentDate = enrollment.EnrollmentDate;
                existingEnrollment.StatusE = enrollment.StatusE;

                return RedirectToAction("Index");
            }

            return View(enrollment);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var enrollment = enrollments.FirstOrDefault(e => e.Id == id);

            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var enrollment = enrollments.FirstOrDefault(e => e.Id == id);

            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var enrollment = enrollments.FirstOrDefault(e => e.Id == id);

            if (enrollment != null)
            {
                enrollments.Remove(enrollment);
            }

            return RedirectToAction("Index");
        }
    }
}
