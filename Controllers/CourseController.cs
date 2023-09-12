using Microsoft.AspNetCore.Mvc;
using CourseManagement.Models;
using System;
using System.Collections.Generic;

namespace CourseManagement.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepository _courseRepository;

        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        private static List<Course> courses = new List<Course>
        {
            new Course { Id = 1, Title = "Genie Logiciel", Description = "Developement & Technologie Web", StatusC = "Ouvert" },
            new Course { Id = 2, Title = "Business", Description = "Marketing Digital", StatusC = "Fermer" },
        };

        // GET: /Course/Index
        [HttpGet]
        public IActionResult Index()
        {
            // Retrieve and display a list of courses
            var courses = _courseRepository.GetAllCourses();
            return View(courses);
        }

        // GET: /Course/Create
        [HttpGet]
        public IActionResult Create()
        {
            // Display a form for creating a new course
            return View();
        }

        // POST: /Course/Create
        [HttpPost]
        public IActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                // Create a new course
                _courseRepository.AddCourse(course);

                // Redirect to the course list
                return RedirectToAction("Index");
            }

            // Debugging code to log model validation errors
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine($"Model error: {error.ErrorMessage}");
            }

            return View(course);
        }

        // GET: /Course/Edit/1
        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Retrieve the course by id and display the edit form
            var course = _courseRepository.GetCourseById(id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: /Course/Edit/1
        [HttpPost]
        public IActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                // Update the course with the new model data
                _courseRepository.UpdateCourse(course);

                // Redirect to the course list
                return RedirectToAction("Index");
            }

            return View(course);
        }

        // GET: /Course/Details/1
        [HttpGet]
        public IActionResult Details(int id)
        {
            // Retrieve and display course details
            var course = _courseRepository.GetCourseById(id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: /Course/Delete/1
        [HttpGet]
        public IActionResult Delete(int id)
        {
            // Retrieve the course by id and display the delete confirmation page
            var course = _courseRepository.GetCourseById(id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: /Course/Delete/1
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            // Delete the course by id
            _courseRepository.DeleteCourse(id);

            // Redirect to the course list
            return RedirectToAction("Index");
        }
    }
}