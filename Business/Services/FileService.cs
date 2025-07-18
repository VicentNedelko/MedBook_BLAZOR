using Microsoft.AspNetCore.Components.Forms;

namespace Business.Services
{
    public static class FileService
    {
        private const int maxFileSize = 4 * 1024 * 1024;
        public static async Task<string> LoadFile(IBrowserFile file)
        {
            try
            {
                var extension = Path.GetExtension(file.Name);
                var newFileName = Path.ChangeExtension(Path.GetRandomFileName(), extension);
                var rootPath = Path.Combine(Directory.GetCurrentDirectory(), "uploads_checkup");
                Directory.CreateDirectory(rootPath);
                var filePath = Path.Combine(rootPath, newFileName);

                await using FileStream fs = new(filePath, FileMode.Create);
                await file.OpenReadStream(maxFileSize).CopyToAsync(fs);

                return filePath;
            }
            catch
            {
                throw;
            }
        }
    }
}
