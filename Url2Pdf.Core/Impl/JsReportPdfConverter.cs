using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using jsreport.Client;
using jsreport.Types;
using Microsoft.AspNetCore.NodeServices;
using Microsoft.Extensions.Options;

namespace Url2Pdf.Core.Impl
{
    internal class JsReportPdfConverter: IPdfConverter
    {
        private JsReportOptions _options;

        public JsReportPdfConverter(IOptions<JsReportOptions> options)
        {
            _options = options.Value;
        }

        public async Task<byte[]> ConvertUrl2Pdf(string url)
        {
            var rs = new ReportingService(_options.Url);
            var content = await FetchHtmlFromUrl(url);
            var report = await rs.RenderAsync(new RenderRequest()
            {
                Template = new Template()
                {
                    Recipe = Recipe.Wkhtmltopdf,
                    Engine = Engine.None,
                    Content = content,
                    //Phantom = new Phantom()
                    //{
                    //    Orientation = PhantomOrientation.Portrait,
                    //    Format = PhantomFormat.A4,
                    //    BlockJavaScript = false,
                    //    PrintDelay = 3000
                    //}
                    Wkhtmltopdf = new Wkhtmltopdf
                    {
                        Orientation = WkhtmltopdfOrientation.Portrait
                    }
                }
            });
            return ReadBytes(report.Content);
        }

        private async Task<string> FetchHtmlFromUrl(string url)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(url);

            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        private static byte[] ReadBytes(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
    }
}
