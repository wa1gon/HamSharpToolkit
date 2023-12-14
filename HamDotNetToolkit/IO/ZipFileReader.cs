using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamDotNetToolkit.IO;

public class ZipFileReader
{
    static string ReadFileFromZip(string zipFile, string fileName)
    {
        try
        {
            using ZipArchive archive = ZipFile.OpenRead(zipFile);
            // Find the specific file in the ZIP
            var entry = archive.GetEntry(fileName);
            if (entry != null)
            {
                // Open a stream to the file
                using Stream stream = entry.Open();

                // Read the contents of the file
                using StreamReader reader = new StreamReader(stream, Encoding.UTF8);

                string fileContents = reader.ReadToEnd();
                return fileContents;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return string.Empty;
    }
}
