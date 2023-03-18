using Microsoft.AspNetCore.Components.Forms;

namespace BlazorAzureBlob.Client.Services.Interfaces;

public interface IBlobService
{
    Task<bool> UploadBlobFile(IBrowserFile file);
}
