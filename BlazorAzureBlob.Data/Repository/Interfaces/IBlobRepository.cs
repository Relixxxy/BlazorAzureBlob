using BlazorAzureBlob.Data.Models;

namespace BlazorAzureBlob.Data.Repository.Interfaces;

public interface IBlobRepository
{
    Task<bool> DeleteBlob(string name);
    Task<BlobObject> GetBlobObject(string name);
    Task<IEnumerable<string>> GetBlobList();
    Task<bool> UploadBlobFile(Stream file, string filename);
}
