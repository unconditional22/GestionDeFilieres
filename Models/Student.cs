namespace StudentManagement.Models
{
    public class Student
    {
        public Student() // Initialisation des Proprietes dans le Constructor
    {
        // FirstName = "";
        // LastName = "";
    }
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
