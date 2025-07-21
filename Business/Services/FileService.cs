using Business.Constants;
using Microsoft.AspNetCore.Components.Forms;

namespace Business.Services
{
    public static class FileService
    {
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
                await file.OpenReadStream(BusinessConstants.maxFileSize).CopyToAsync(fs);

                return filePath;
            }
            catch
            {
                throw;
            }
        }

        public static void DeleteFile(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch
            {
                throw;
            }
        }
    }
}
