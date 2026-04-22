namespace ACE.Contracts.Documents;

public class CreateDocumentRequest
{
    public Guid ProjectId { get; set; }
    public string FileName { get; set; } = string.Empty;
    public string FileType { get; set; } = string.Empty;
    public string StoragePath { get; set; } = string.Empty;
}