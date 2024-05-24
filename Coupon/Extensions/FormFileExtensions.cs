namespace Coupon.Extensions;

public static class FormFileExtensions
{
    public static async Task<string> SaveFileAsync(this IFormFile file, string rootPath, string folderName)
    {
        // Create directory if it does not exist
        string directoryPath = Path.Combine(rootPath, folderName);
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        // Generate a unique filename to avoid overwriting existing files
        string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
        string filePath = Path.Combine(directoryPath, uniqueFileName);

        // Save the file to the specified path
        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(fileStream);
        }

        // Return the relative path of the file
        return Path.Combine(folderName, uniqueFileName).Replace("\\", "/");
    }
}