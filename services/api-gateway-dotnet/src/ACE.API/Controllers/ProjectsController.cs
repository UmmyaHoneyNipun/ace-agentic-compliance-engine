using Microsoft.AspNetCore.Mvc;
using ACE.Contracts.Projects;
using ACE.Domain.Entities;
using ACE.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ACE.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly AceDbContext _dbContext;

    public ProjectsController(AceDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProjectResponse>>> GetProjects()
    {
        var projects = await _dbContext.Projects
            .OrderByDescending(x => x.CreatedAt)
            .Select(x => new ProjectResponse
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                CreatedBy = x.CreatedBy,
                CreatedAt = x.CreatedAt
            })
            .ToListAsync();

        return Ok(projects);
    }

    [HttpPost]
    public async Task<ActionResult<ProjectResponse>> CreateProject(CreateProjectRequest request)
    {
        try{
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                return BadRequest("Project name is required.");
            }

            var project = new Project
            {
                Id = Guid.NewGuid(),
                Name = request.Name.Trim(),
                Description = request.Description?.Trim(),
                CreatedBy = Guid.Empty,
                CreatedAt = DateTime.UtcNow
            };

            _dbContext.Projects.Add(project);
            await _dbContext.SaveChangesAsync();

            var response = new ProjectResponse
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                CreatedBy = project.CreatedBy,
                CreatedAt = project.CreatedAt
            };

            return CreatedAtAction(nameof(GetProjects), new { id = project.Id }, response);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.ToString());
        }
    }
}