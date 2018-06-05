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
            services.Configure<AthenaOptions>(options =>
            {
                options.Url = Environment.GetEnvironmentVariable("ATHENA_URL");
                options.Key = Environment.GetEnvironmentVariable("ATHENA_KEY");
            });

            services.AddTransient<IPdfConverter, AthenaPdfConverter>();

            services.AddTransient<IPdfConversionService, PdfConversionService>();
        }
    }
}
