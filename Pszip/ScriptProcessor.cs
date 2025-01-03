﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pszip
{
    internal class ScriptProcessor
    {
        public static void CreateScript(IEnumerable<string> fileList)
        {
            var outFile = Environment.CurrentDirectory + "\\unpack.ps1";
            var outStream = File.Create(outFile);
            var sw = new StreamWriter(outStream);

            sw.WriteLine("$ZipFilesAndFolders = @{");

            var formattedEntries = fileList.Select(file => $"\t'{file}' = '{Path.GetFileNameWithoutExtension(file)}'");

            foreach (var entry in formattedEntries)
            {
                sw.WriteLine(entry);
            }

            sw.WriteLine("}");
            sw.WriteLine("");
            sw.WriteLine("foreach ($KeyAndValue in $ZipFilesAndFolders.GetEnumerator())");
            sw.WriteLine("{");
            sw.WriteLine("\t$ZipFilePath = $KeyAndValue.Key");
            sw.WriteLine("\t$DestinationPath = $KeyAndValue.Value");
            sw.WriteLine();
            sw.WriteLine("\tExpand-Archive -LiteralPath $ZipFilePath -DestinationPath $DestinationPath");
            sw.WriteLine("}");

            // flush and close
            sw.Flush();
            sw.Close();
        }
    }
}
