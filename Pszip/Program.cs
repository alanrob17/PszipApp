using System.Diagnostics;

namespace Pszip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fileDirectory = Environment.CurrentDirectory + @"\";
            var fileList = FileSystemHelper.GetFileList(fileDirectory);

            ScriptProcessor.CreateScript(fileList);
            Console.WriteLine("Finished...");
        }
    }
}
