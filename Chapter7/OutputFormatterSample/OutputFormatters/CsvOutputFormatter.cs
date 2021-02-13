using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using OutputFormatterSample.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.IO;

namespace OutputFormatterSample.OutputFormatters
{
    public class CsvOutputFormatter : TextOutputFormatter
    {
        public CsvOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }
        protected override bool CanWriteType(Type type)
        {
            if (typeof(Person).IsAssignableFrom(type) || typeof(IEnumerable<Person>).IsAssignableFrom(type))
            {
                return base.CanWriteType(type);
            }
            return false;
        }

        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var serviceProvider = context.HttpContext.RequestServices;
            var logger = serviceProvider.GetService(typeof(ILogger<CsvOutputFormatter>)) as ILogger;
            var response = context.HttpContext.Response;
            if (context.Object is IEnumerable<Person>)
            {
                using (var csvWriter = new CsvWriter(new StreamWriter(response.Body), CultureInfo.InvariantCulture))
                {
                    csvWriter.WriteHeader<Person>();
                    await csvWriter.WriteRecordsAsync(context.Object as IEnumerable<Person>);
                    
                }
            }
            else
            {
                using (var csvWriter = new CsvWriter(new StreamWriter(response.Body), CultureInfo.InvariantCulture))
                {
                    csvWriter.WriteHeader<Person>();
                    await csvWriter.WriteRecordsAsync(new List<Person> { context.Object as Person});
                }
            }
        }
    }
}
