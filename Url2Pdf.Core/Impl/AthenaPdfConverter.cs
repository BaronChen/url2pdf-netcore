using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.NodeServices;
using Microsoft.Extensions.Options;

namespace Url2Pdf.Core.Impl
{
    internal class AthenaPdfConverter: IPdfConverter
    {
        private AthenaOptions _options;

        public AthenaPdfConverter(IOptions<AthenaOptions> options)
        {
            _options = options.Value;
        }

        public async Task<byte[]> ConvertUrl2Pdf(string url)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(GetAthenaUrl(url));
            return await response.Content.ReadAsByteArrayAsync();
        }

        private string GetAthenaUrl(string url)
        {
            return $"{_options.Url}/convert?auth={_options.Key}&url={HttpUtility.UrlEncode(url)}";
        }

        //private async Task<string> FetchHtmlFromUrl(string url)
        //{
        //    var client = new HttpClient();
        //    var response = await client.GetAsync(url);

        //    var content = await response.Content.ReadAsStringAsync();
        //    return content;
        //}

        //private static byte[] ReadBytes(Stream input)
        //{
        //    byte[] buffer = new byte[16 * 1024];
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        int read;
        //        while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
        //        {
        //            ms.Write(buffer, 0, read);
        //        }
        //        return ms.ToArray();
        //    }
        //}
    }
}
