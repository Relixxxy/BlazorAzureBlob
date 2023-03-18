using BlazorAzureBlob.Client.Services.Interfaces;
using BlazorAzureBlob.Client.Validation;
using BlazorAzureBlob.Data.Repository.Interfaces;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorAzureBlob.Client.Services;

public class BlobService : IBlobService
{
    private readonly IBlobRepository _blobRepository;
    private readonly BlobFileValidator _validator;

    public BlobService(IBlobRepository blobRepository, BlobFileValidator validator)
    {
        _blobRepository = blobRepository;
        _validator = validator;
    }

    public async Task<bool> UploadBlobFile(IBrowserFile file)
    {
        var validationResult = _validator.Validate(file);

        if (validationResult.IsValid)
        {
            using var stream = file.OpenReadStream();
            var result = await _blobRepository.UploadBlobFile(stream, file.Name);

            return result;
        }

        return false;
    }
}
