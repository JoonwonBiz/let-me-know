using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Methods
    {
        public static bool IsExistDirectory(string directoryPath)
        {
            return Directory.Exists(directoryPath);
        }

        public static void CreateDirectory(string directoryPath)
        {
            string directory = directoryPath.GetDirectoryPath();

            if (IsExistDirectory(directory) == false)
            {
                Directory.CreateDirectory(directory);
            }
        }

        public static void SaveFile(string filePath, string content, bool isAppend = true)
        {
            if (isAppend)
            {
                File.AppendAllText(filePath, content, Encoding.UTF8);
            }
            else
            {
                File.WriteAllText(filePath, content, Encoding.GetEncoding(949));
            }
        }
    }
}
