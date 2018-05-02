using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Url2Pdf.Core
{
    public interface IUrl2PdfConversionService
    {
        Task<byte[]> ConverUrlToPdf(string url);
    }
}
