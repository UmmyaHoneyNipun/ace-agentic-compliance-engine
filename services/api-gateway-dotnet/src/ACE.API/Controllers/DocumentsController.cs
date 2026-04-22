using ACE.Contracts.Documents;
using ACE.Domain.Entities;
using ACE.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ACE.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DocumentsController : ControllerBase
{
    private readonly AceDbContext _dbContext;

    public DocumentsController(AceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DocumentResponse>>> GetDocuments()
    {
        var documents = await _dbContext.Documents
            .OrderByDescending(x => x.UploadedAt)
            .Select(x => new DocumentResponse
            {
                Id = x.Id,
                ProjectId = x.ProjectId,
                FileName = x.FileName,
                FileType = x.FileType,
                StoragePath = x.StoragePath,
                Status = x.Status,
                UploadedBy = x.UploadedBy,
                UploadedAt = x.UploadedAt
            })
            .ToListAsync();

        return Ok(documents);
    }

    [HttpPost]
    public async Task<ActionResult<DocumentResponse>> CreateDocument(CreateDocumentRequest request)
    {
        if (request.ProjectId == Guid.Empty)
        {
            return BadRequest("ProjectId is required.");
        }

        if (string.IsNullOrWhiteSpace(request.FileName))
        {
            return BadRequest("FileName is required.");
        }

        if (string.IsNullOrWhiteSpace(request.FileType))
        {
            return BadRequest("FileType is required.");
        }

        if (string.IsNullOrWhiteSpace(request.StoragePath))
        {
            return BadRequest("StoragePath is required.");
        }

        var projectExists = await _dbContext.Projects.AnyAsync(x => x.Id == request.ProjectId);
        if (!projectExists)
        {
            return BadRequest("The specified project does not exist.");
        }

        var document = new Document
        {
            Id = Guid.NewGuid(),
            ProjectId = request.ProjectId,
            FileName = request.FileName.Trim(),
            FileType = request.FileType.Trim(),
            StoragePath = request.StoragePath.Trim(),
            Status = "Pending",
            UploadedBy = Guid.Empty,
            UploadedAt = DateTime.UtcNow
        };

        _dbContext.Documents.Add(document);
        await _dbContext.SaveChangesAsync();

        var response = new DocumentResponse
        {
            Id = document.Id,
            ProjectId = document.ProjectId,
            FileName = document.FileName,
            FileType = document.FileType,
            StoragePath = document.StoragePath,
            Status = document.Status,
            UploadedBy = document.UploadedBy,
            UploadedAt = document.UploadedAt
        };

        return CreatedAtAction(nameof(GetDocuments), new { id = document.Id }, response);
    }
}