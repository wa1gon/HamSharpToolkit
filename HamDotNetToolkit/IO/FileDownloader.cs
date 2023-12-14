using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamDotNetToolkit.IO;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;

public class FileDownloader
{
    private readonly HttpClient client;

    public FileDownloader()
    {
        client = new HttpClient();
    }

    public async Task<string> DownloadFileAsync(string fileUrl)
    {
        try
        {
            string filePath = Path.GetTempFileName();
            HttpResponseMessage response = await client.GetAsync(fileUrl, HttpCompletionOption.ResponseHeadersRead);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error: {response.StatusCode}");
            }


            await using var stream = await response.Content.ReadAsStreamAsync();
            await using var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None);
            await stream.CopyToAsync(fileStream);
            return filePath;
        }
        catch (Exception)
        {
            throw;
        }
    }
}

