namespace ACE.Domain.Entities;

public class Document
{
    public Guid Id { get; set; }
    public Guid ProjectId { get; set; }
    public string FileName { get; set; } = string.Empty;
    public string FileType { get; set; } = string.Empty;
    public string StoragePath { get; set; } = string.Empty;
    public string Status { get; set; } = "Pending";
    public Guid UploadedBy { get; set; }
    public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
}