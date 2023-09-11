using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models;

namespace StudentManagement.Controllers
{
    public class StudentController : Controller
    {
        // Sample data (you can replace this with your database logic)
        private static List<Student> students = new List<Student>
        {
            new Student { Id = 1, FirstName = "John", LastName = "Doe" },
            new Student { Id = 2, FirstName = "Jane", LastName = "Smith" }
        };

        public IActionResult Index()
        {
            // Display a list of students
            return View(students);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                // Add the new student to the list (you can replace this with your database logic)
                student.Id = students.Max(s => s.Id) + 1;
                students.Add(student);

                return RedirectToAction("Index");
            }

            return View(student);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                var existingStudent = students.FirstOrDefault(s => s.Id == student.Id);

                if (existingStudent == null)
                {
                    return NotFound();
                }

                existingStudent.FirstName = student.FirstName;
                existingStudent.LastName = student.LastName;

                return RedirectToAction("Index");
            }

            return View(student);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);

            if (student != null)
            {
                students.Remove(student);
            }

            return RedirectToAction("Index");
        }
    }
}
