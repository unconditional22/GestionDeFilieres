using System;
using System.Collections.Generic;
using System.Linq;
using CourseManagementSystem.Data;
using CourseManagement.Models;
using StudentManagement.Models;


    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context; // Assuming Entity Framework

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _context.Students.ToList();
        }

        public Student GetStudentById(int id)
        {
            // Implement logic to retrieve a student by ID
            return _context.Students.FirstOrDefault(student => student.Id == id);
        }

        public void AddStudent(Student student)
        {
            // Implement logic to add a new student to the database
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void UpdateStudent(Student student)
        {
            // Implement logic to update an existing student in the database
            _context.Students.Update(student);
            _context.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            // Implement logic to delete a student from the database by ID
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
        }
    }

