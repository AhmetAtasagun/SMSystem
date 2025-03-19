using Microsoft.AspNetCore.Http;

namespace SMSystem.Application.Services.Storage
{
    public interface IFileService
    {
        /// <summary>
        /// Uploads a file and returns the file path
        /// </summary>
        /// <param name="file">The file to upload</param>
        /// <param name="folderName">Optional folder name to store the file in</param>
        /// <returns>The path to the uploaded file</returns>
        Task<string> UploadAsync(IFormFile file, string folderName = null);

        /// <summary>
        /// Deletes a file
        /// </summary>
        /// <param name="filePath">The path to the file to delete</param>
        /// <returns>True if the file was deleted successfully</returns>
        Task<bool> DeleteAsync(string filePath);
    }
}