namespace FitnessApp1.Utilities.Extensions
{
    public static class FileExtension
    {
        public static bool CheckFileType(this IFormFile file, string type)
        {
            if (file.ContentType.Contains(type))
            {
                return true;
            }
            return false;
        }
        public static bool CheckFileSize(this IFormFile file, int kb)
        {
            if (file.Length <= kb * 1024)
            {
                return true;
            }
            return false;
        }
        public static async Task<string> CreateFileAsync(this IFormFile file, string root, string folder)
        {
            string filename = Guid.NewGuid().ToString() + file.FileName;
            string path = Path.Combine(root, folder, filename);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return filename;
        }
        public static void DeleteFile(this string filename, string root, string folder)
        {
            string path = Path.Combine(root, folder, filename);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
        public static void DeleteImage(IWebHostEnvironment env, string folder, string file)
        {
            string path = env.WebRootPath;
            string result = Path.Combine(path, folder, file);

            if (System.IO.File.Exists(result))
            {
                System.IO.File.Delete(result);
            }

        }
        public static void Deletemage(string path)
        {
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            };
        }
    }
}
