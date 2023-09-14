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

// Sample Data
public class SampleCourseRepository : ICourseRepository
{
    private static List<Course> courses = new List<Course>
    {
        new Course { Id = 1, Title = "Genie Logiciel", Description = "Developement & Technologie Web", StatusC = "Ouvert" },
        new Course { Id = 2, Title = "Business", Description = "Marketing Digital", StatusC = "Fermer" }
    };

    public void AddCourse(Course course)
    {
        courses.Add(course);
    }

    public void DeleteCourse(int id)
    {
        var course = courses.FirstOrDefault(c => c.Id == id);
        if (course != null)
        {
            courses.Remove(course);
        }
    }

    public IEnumerable<Course> GetAllCourses()
    {
        return courses;
    }

    public Course GetCourseById(int id)
    {
        return courses.FirstOrDefault(c => c.Id == id);
    }

    public void UpdateCourse(Course course)
    {
        var existingCourse = courses.FirstOrDefault(c => c.Id == course.Id);
        if (existingCourse != null)
        {
            existingCourse.Title = course.Title;
            existingCourse.Description = course.Description;
            existingCourse.StatusC = course.StatusC;
        }
    }
}