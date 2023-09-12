using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models;

namespace StudentManagement.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;

    public StudentController(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

        // Sample data (you can replace this with your database logic)
        private static List<Student> students = new List<Student>
        {
            new Student { Id = 1, FirstName = "John", LastName = "Doe" },
            new Student { Id = 2, FirstName = "Jane", LastName = "Smith" }
        };

        // GET: /Student/Index
        [HttpGet]
        public IActionResult Index()
        {
            // Retrieve and display a list of students using the repository
            var students = _studentRepository.GetAllStudents();
            return View(students);
        }

        // GET: /Student/Create
        [HttpGet]
        public IActionResult Create()
        {
            // Display a form for creating a new student
            return View();
        }

        // POST: /Student/Create
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                // Create a new student using the repository
                _studentRepository.AddStudent(student);

                // Redirect to the student list
                return RedirectToAction("Index");
            }

            // Debugging code to log model validation errors
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine($"Model error: {error.ErrorMessage}");
            }

            return View(student);
        }

        // GET: /Student/Edit/1
        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Retrieve the student by id and display the edit form
            var student = _studentRepository.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: /Student/Edit/1
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                // Update the student with the new model data using the repository
                _studentRepository.UpdateStudent(student);

                // Redirect to the student list
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: /Student/Details/1
        [HttpGet]
        public IActionResult Details(int id)
        {
            // Retrieve and display student details using the repository
            var student = _studentRepository.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: /Student/Delete/1
        [HttpGet]
        public IActionResult Delete(int id)
        {
            // Retrieve the student by id and display the delete confirmation page
            var student = _studentRepository.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: /Student/Delete/1
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            // Delete the student by id using the repository
            _studentRepository.DeleteStudent(id);

            // Redirect to the student list
            return RedirectToAction("Index");
        }
    }
}