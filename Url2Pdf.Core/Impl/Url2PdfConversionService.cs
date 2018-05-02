using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.NodeServices;

namespace Url2Pdf.Core.Impl
{
    public class Url2PdfConversionService : IUrl2PdfConversionService
    {
        private readonly INodeServices _nodeServices;

        public Url2PdfConversionService(INodeServices nodeServices)
        {
            _nodeServices = nodeServices;
        }

        public async Task<byte[]> ConverUrlToPdf(string url)
        {
            var converter = new Url2PdfConverter(_nodeServices);

            return await converter.ConvertUrl2Pdf(url);
        }
    }
}
