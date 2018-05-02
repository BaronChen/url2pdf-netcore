using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.NodeServices;

namespace Url2Pdf.Core
{
    internal class Url2PdfConverter
    {
        private readonly INodeServices _nodeServices;

        public Url2PdfConverter(INodeServices nodeServices)
        {
            _nodeServices = nodeServices;
        }

        public async Task<byte[]> ConvertUrl2Pdf(string url)
        {
            var result = await _nodeServices.InvokeAsync<string>("./url2pdf", url);

            return Convert.FromBase64String(result);
        }
    }
}
