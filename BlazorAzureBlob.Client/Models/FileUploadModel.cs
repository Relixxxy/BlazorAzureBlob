using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorAzureBlob.Client.Models;

public class FileUploadModel
{
    [Required(ErrorMessage = "Please choose a file.")]
    public IBrowserFile File { get; set; } = null!;
}