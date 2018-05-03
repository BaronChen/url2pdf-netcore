using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Url2Pdf.Core;

namespace Url2Pdf.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/url-2-pdf")]
    public class Url2PdfController : Controller
    {

        private IUrl2PdfConversionService _url2PdfConversionService;

        public Url2PdfController(IUrl2PdfConversionService url2PdfConversionService)
        {
            _url2PdfConversionService = url2PdfConversionService;
        }

        [HttpGet, Route("")]
        public IActionResult Index()
        {
            return Ok("Welcome!!");
        }


        [HttpGet, Route("convert")]
        public async Task<IActionResult> Convert([FromQuery]string url)
        {
            var result = await _url2PdfConversionService.ConverUrlToPdf(HttpUtility.UrlDecode(url));
            
            string filename = @"converted.pdf";
            
            return File(result, "application/pdf", filename);
        }


    }
}