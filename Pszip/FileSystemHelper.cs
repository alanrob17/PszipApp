using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pszip
{
    internal class FileSystemHelper
    {
        public static IEnumerable<string> GetFileList(string folder)
        {
            var dir = new DirectoryInfo(folder);
            var fileList = new List<string>();

            GetFiles(dir, fileList);

            return fileList;
        }

        private static void GetFiles(DirectoryInfo d, ICollection<string> fileList)
        {
            var files = d.GetFiles("*.zip");

            foreach (var fileName in files.Select(file => file.FullName))
            {
                var name = Path.GetFileName(fileName);
                fileList.Add(name);
            }
        }
    }
}
