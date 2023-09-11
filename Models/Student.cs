using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Models
{
    public class Student
    {

  

        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; }
    }
}
