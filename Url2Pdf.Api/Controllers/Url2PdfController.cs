using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<IActionResult> Convert()
        {
            var result = await _url2PdfConversionService.ConverUrlToPdf("http://www.google.com");

            HttpContext.Response.ContentType = "application/pdf";

            string filename = @"converted.pdf";
            HttpContext.Response.Headers.Add("x-filename", filename);
            HttpContext.Response.Headers.Add("Access-Control-Expose-Headers", "x-filename");
            HttpContext.Response.Body.Write(result, 0, result.Length);
            return new ContentResult();
        }


    }
}