using FluentValidation;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorAzureBlob.Client.Validation;

public class BlobFileValidator : AbstractValidator<IBrowserFile>
{
    public BlobFileValidator(int maxFileSize, string[] allowedExtensions)
    {
        RuleFor(file => file.Size)
            .NotNull().WithMessage("File cannot be null")
            .LessThanOrEqualTo(maxFileSize).WithMessage($"File size cannot exceed {maxFileSize} bytes");

        RuleFor(file => Path.GetExtension(file.Name))
            .NotNull().WithMessage("File extension cannot be null")
            .Must(extension => allowedExtensions.Contains(extension.ToLower())).WithMessage($"Invalid file extension. Allowed extensions are: {string.Join(",", allowedExtensions)}");
    }
}
