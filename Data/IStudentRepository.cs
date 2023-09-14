using System.Collections.Generic;
using CourseManagementSystem.Data;
using CourseManagement.Models;
using System;
using System.Linq;
using StudentManagement.Models;


    public interface IStudentRepository
    {
        IEnumerable<Student> GetAllStudents();
        Student GetStudentById(int id);
        void AddStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(int id);
    }

    // Sample Data
    public class SampleStudentRepository : IStudentRepository
    {
        private static List<Student> students = new List<Student>
        {
            new Student { Id = 1, FirstName = "John", LastName = "Doe" },
            new Student { Id = 2, FirstName = "Jane", LastName = "Smith" }
        };

        public IEnumerable<Student> GetAllStudents()
        {
            return students;
        }

        public Student GetStudentById(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public void UpdateStudent(Student student)
        {
            var existingStudent = students.FirstOrDefault(s => s.Id == student.Id);
            if (existingStudent != null)
            {
                existingStudent.FirstName = student.FirstName;
                existingStudent.LastName = student.LastName;
            }
        }

        public void DeleteStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                students.Remove(student);
            }
        }
    }
