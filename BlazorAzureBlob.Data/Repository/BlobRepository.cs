using Azure.Storage.Blobs;
using BlazorAzureBlob.Data.Models;
using BlazorAzureBlob.Data.Repository.Interfaces;

namespace BlazorAzureBlob.Data.Repository;

public class BlobRepository : IBlobRepository
{
    private readonly BlobServiceClient _blobServiceClient;
    private readonly BlobContainerClient _client;

    public BlobRepository(BlobServiceClient blobServiceClient)
    {
        _blobServiceClient = blobServiceClient;
        _client = _blobServiceClient.GetBlobContainerClient("blobcontainer");
    }

    public Task<bool> DeleteBlob(string name)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<string>> GetBlobList()
    {
        throw new NotImplementedException();
    }

    public Task<BlobObject> GetBlobObject(string name)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UploadBlobFile(Stream file, string filename)
    {
        try
        {
            var blobClient = _client.GetBlobClient(filename);
            var status = await blobClient.UploadAsync(file);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
