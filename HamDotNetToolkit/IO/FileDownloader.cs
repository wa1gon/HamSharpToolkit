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

    public async Task DownloadFileAsync(string fileUrl, string filePath)
    {
        try
        {
            HttpResponseMessage response = await client.GetAsync(fileUrl, HttpCompletionOption.ResponseHeadersRead);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error: {response.StatusCode}");
            }

            using (var stream = await response.Content.ReadAsStreamAsync())
            using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                await stream.CopyToAsync(fileStream);
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}

