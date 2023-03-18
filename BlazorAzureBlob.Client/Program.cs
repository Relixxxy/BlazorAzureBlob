using Azure.Storage.Blobs;
using BlazorAzureBlob.Client.Services;
using BlazorAzureBlob.Client.Services.Interfaces;
using BlazorAzureBlob.Client.Validation;
using BlazorAzureBlob.Data.Repository;
using BlazorAzureBlob.Data.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var maxFileSize = builder.Configuration.GetValue<int>("BlobConfig:MaxFileSize");
var fileExtensions = builder.Configuration.GetSection("BlobConfig:FileExtensions").Get<string[]>();
builder.Services.AddTransient(sp => new BlobFileValidator(maxFileSize, fileExtensions!));

builder.Services.AddSingleton(x => new BlobServiceClient(builder.Configuration.GetConnectionString("AzureBlobConnectionString")));
builder.Services.AddTransient<IBlobRepository, BlobRepository>();
builder.Services.AddTransient<IBlobService, BlobService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();