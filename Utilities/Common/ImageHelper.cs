using Microsoft.AspNetCore.Http;

namespace Utilities.Common
{
    public class ImageHelper
    {
        public async Task<string> SaveImageAsync(IFormFile? file, string? folderPath)
        {
            // Check if the file is null or empty
            if (file == null || file.Length == 0)
            {
                return "File is emty or null";
            }

            // Check if the folderPath is null or empty
            if (file == null || file.Length == 0)
            {
                return "Folder path is emty or null";
            }

            // Check file type (e.g., only allow jpg, png, gif)
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
            var fileExtension = Path.GetExtension(file.FileName).ToLower();
            if (!allowedExtensions.Contains(fileExtension))
            {
                return "Invalid file type";
            }

            // Generate a unique file name to avoid conflicts
            var fileName = $"{Guid.NewGuid()}{fileExtension}";
            var filePath = Path.Combine(folderPath, fileName);

            // Ensure the folder exists
            Directory.CreateDirectory(folderPath);

            // Save the file
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return fileName; // Return the name of the saved file
        }
    }
}
