using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Url2Pdf.Core
{
    public interface IPdfConversionService
    {
        Task<byte[]> ConverUrlToPdf(string url);
    }
}
