using Microsoft.AspNetCore.Mvc;

namespace ACE.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DocumentsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetDocuments()
    {
        var documents = new[]
        {
            new
            {
                Id = Guid.NewGuid(),
                FileName = "sample-financial-report.pdf",
                Status = "Pending"
            }
        };

        return Ok(documents);
    }
}