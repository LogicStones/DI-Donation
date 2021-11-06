using Microsoft.AspNetCore.Http;
using System.IO;

namespace Services
{
    public class FilesManagerService
    {
        public static string UploadFile(IFormFile file, string path, string fileName)
        {
            //string fileNameWithExtension = fileName + Path.GetExtension(file.FileName);
            string fileNameWithExtension = fileName;
            string pathWithFileName = Path.Combine(path, fileNameWithExtension);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            DeleteFile(path, fileName);

            if (file.Length > 0)
            {
                using (var stream = new FileStream(pathWithFileName, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }

            return fileNameWithExtension;
        }

        public static void DeleteFile(string path, string fileName)
        {
            string[] files = Directory.GetFiles(path, fileName + ".*");

            foreach (string item in files)
            {
                File.Delete(item);
            }
        }
    }
}