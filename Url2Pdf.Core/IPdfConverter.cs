using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Url2Pdf.Core
{
    public interface IPdfConverter
    {
        Task<byte[]> ConvertUrl2Pdf(string url);
    }
}
