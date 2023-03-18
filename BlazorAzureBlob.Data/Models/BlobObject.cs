namespace BlazorAzureBlob.Data.Models;

public class BlobObject
{
    public Stream Content { get; set; } = null!;
    public string ContentType { get; set; } = null!;
}
