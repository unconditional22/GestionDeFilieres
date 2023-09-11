using Microsoft.AspNetCore.Mvc;
using CourseManagement.Models; // Make sure to include your model namespace

public class CourseController : Controller
{
    private readonly ICourseRepository _courseRepository;

    public CourseController(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }
    
    // GET: /Course/Index
    [HttpGet]
    public IActionResult Index()
    {
        // Logic to retrieve and display a list of courses
        var courses = _courseRepository.GetAllCourses();
        return View(courses);
        return View();
    }

    // GET: /Course/Create
    [HttpGet]
    public IActionResult Create()
    {
        // Logic to display a form for creating a new course
        return View();
    }

    // POST: /Course/Create
    [HttpPost]
    public IActionResult Create(Course model)
    {
        // Logic to create a new course
        // Example: _courseRepository.CreateCourse(model);
        return RedirectToAction("Index");
    }

    // GET: /Course/Edit/1
    [HttpGet]
    public IActionResult Edit(int id)
    {
        // Logic to retrieve the course by id and display the edit form
        // Example: var course = _courseRepository.GetCourseById(id);
        // return View(course);
        return View();
    }

    // POST: /Course/Edit/1
    [HttpPost]
    public IActionResult Edit(int id, Course model)
    {
        // Logic to update the course with the new model data
        // Example: _courseRepository.UpdateCourse(id, model);
        return RedirectToAction("Index");
    }

    // GET: /Course/Details/1
    [HttpGet]
    public IActionResult Details(int id)
    {
        // Logic to retrieve and display course details
        // Example: var course = _courseRepository.GetCourseById(id);
        // return View(course);
        return View();
    }

    // GET: /Course/Delete/1
    [HttpGet]
    public IActionResult Delete(int id)
    {
        // Logic to retrieve the course by id and display the delete confirmation page
        // Example: var course = _courseRepository.GetCourseById(id);
        // return View(course);
        return View();
    }

    // POST: /Course/Delete/1
    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        // Logic to delete the course by id
        // Example: _courseRepository.DeleteCourse(id);
        return RedirectToAction("Index");
    }
}
