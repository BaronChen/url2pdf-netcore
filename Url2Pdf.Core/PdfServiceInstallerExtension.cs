using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Url2Pdf.Core.Impl;

namespace Url2Pdf.Core
{
    public static class PdfServiceInstallerExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.Configure<JsReportOptions>(options =>
            {
                options.Url = Environment.GetEnvironmentVariable("JSREPORT_URL");
            });

            services.AddTransient<IPdfConverter, JsReportPdfConverter>();

            services.AddTransient<IPdfConversionService, PdfConversionService>();
        }
    }
}
