using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.NodeServices;

namespace Url2Pdf.Core.Impl
{
    internal class PdfConversionService : IPdfConversionService
    {
        private IPdfConverter _pdfConverter;

        public PdfConversionService(IPdfConverter pdfConverter)
        {
            this._pdfConverter = pdfConverter;
        }

        public async Task<byte[]> ConverUrlToPdf(string url)
        {

            return await _pdfConverter.ConvertUrl2Pdf(url);
        }
    }
}
