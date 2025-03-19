using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using SMSystem.Application.Services.Storage;

namespace SMSystem.Infrastructure.Storage
{
    public class LocalFileService : IFileService
    {
        private readonly IHostEnvironment _hostEnvironment;

        public LocalFileService(IHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        public async Task<string> UploadAsync(IFormFile file, string folderName = null)
        {
            if (file == null || file.Length == 0)
                return null;

            var uploadsFolder = Path.Combine(_hostEnvironment.ContentRootPath, "wwwroot", "uploads");
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            if (!string.IsNullOrEmpty(folderName))
            {
                uploadsFolder = Path.Combine(uploadsFolder, folderName);
                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);
            }

            var uniqueFileName = $"{Guid.NewGuid()}_{Path.GetFileName(file.FileName)}";
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return Path.Combine("uploads", folderName ?? string.Empty, uniqueFileName).Replace("\\", "/");
        }

        public Task<bool> DeleteAsync(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                return Task.FromResult(false);

            try
            {
                var fullPath = Path.Combine(_hostEnvironment.ContentRootPath, "wwwroot", filePath.TrimStart('/'));
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                    return Task.FromResult(true);
                }
                return Task.FromResult(false);
            }
            catch
            {
                return Task.FromResult(false);
            }
        }
    }
}