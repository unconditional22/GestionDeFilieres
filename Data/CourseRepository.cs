using CourseManagementSystem.Data;
using CourseManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

// CourseRepository.cs
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context; // Assuming Entity Framework

        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return _context.Courses.ToList();
        }

        public Course GetCourseById(int id)
        {
            // Implement logic to retrieve a course by ID
            return _context.Courses.FirstOrDefault(course => course.Id == id);
        }

        public void AddCourse(Course course)
        {
            // Implement logic to add a new course to the database
            _context.Courses.Add(course);
            _context.SaveChanges();
        }

        public void UpdateCourse(Course course)
        {
            // Implement logic to update an existing course in the database
            _context.Courses.Update(course);
            _context.SaveChanges();
        }

        public void DeleteCourse(int id)
        {
            // Implement logic to delete a course from the database by ID
            var course = _context.Courses.FirstOrDefault(c => c.Id == id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();
            }
        }
    }
