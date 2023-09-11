using CourseManagementSystem.Data;
using CourseManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;


// ICourseRepository.cs
public interface ICourseRepository
{
    IEnumerable<Course> GetAllCourses();
    Course GetCourseById(int id);
    void AddCourse(Course course);
    void UpdateCourse(Course course);
    void DeleteCourse(int id);
}
