using Microsoft.AspNetCore.Mvc;
using TeamCityTestApp.WebApi.Models;

namespace TeamCityTestApp.WebApi.Controllers;

[Route("[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        List<Student> students = new List<Student>
        {
            new Student("John", "Doe", 20),
            new Student("Jane", "Doe", 22),
            new Student("Peter", "Jackson", 30),
        };

        return Ok(students);
    }
}
