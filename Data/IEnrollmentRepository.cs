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

