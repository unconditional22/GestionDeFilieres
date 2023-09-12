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

