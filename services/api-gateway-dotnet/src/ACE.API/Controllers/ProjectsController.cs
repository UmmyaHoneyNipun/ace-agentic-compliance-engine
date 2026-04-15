using Microsoft.AspNetCore.Mvc;

namespace ACE.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetProjects()
    {
        var projects = new[]
        {
            new
            {
                Id = Guid.NewGuid(),
                Name = "Financial Compliance Demo",
                Description = "Seed project for ACE"
            }
        };

        return Ok(projects);
    }
}