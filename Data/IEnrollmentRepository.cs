using System.Collections.Generic;
using CourseManagementSystem.Data;
using EnrollmentManagement.Models;
using System;
using System.Linq;

    public interface IEnrollmentRepository
    {
        IEnumerable<Enrollment> GetAllEnrollments();
        Enrollment GetEnrollmentById(int id);
        void AddEnrollment(Enrollment enrollment);
        void UpdateEnrollment(Enrollment enrollment);
        void DeleteEnrollment(int id);
    }

    // Sample Data
    public class SampleEnrollmentRepository : IEnrollmentRepository
    {
        private static List<Enrollment> enrollments = new List<Enrollment>
        {
            new Enrollment { Id = 1, StudentId = 1, CourseId = 1, EnrollmentDate = DateTime.Now, StatusE = "Active" },
            new Enrollment { Id = 2, StudentId = 2, CourseId = 2, EnrollmentDate = DateTime.Now, StatusE = "Complete" }
        };

        public void AddEnrollment(Enrollment enrollment)
        {
            enrollments.Add(enrollment);
        }

        public void DeleteEnrollment(int id)
        {
            var enrollment = enrollments.FirstOrDefault(e => e.Id == id);
            if (enrollment != null)
            {
                enrollments.Remove(enrollment);
            }
        }

        public IEnumerable<Enrollment> GetAllEnrollments()
        {
            return enrollments;
        }

        public Enrollment GetEnrollmentById(int id)
        {
            return enrollments.FirstOrDefault(e => e.Id == id);
        }

        public void UpdateEnrollment(Enrollment enrollment)
        {
            var existingEnrollment = enrollments.FirstOrDefault(e => e.Id == enrollment.Id);
            if (existingEnrollment != null)
            {
                existingEnrollment.StudentId = enrollment.StudentId;
                existingEnrollment.CourseId = enrollment.CourseId;
                existingEnrollment.EnrollmentDate = enrollment.EnrollmentDate;
                existingEnrollment.StatusE = enrollment.StatusE;
            }
        }
    }
