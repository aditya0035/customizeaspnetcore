using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Net.Http.Headers;
using InputFormatterSample.Models;
using Microsoft.Extensions.Logging;
using CsvHelper;
using System.IO;
using CsvHelper.Configuration;
using System.Globalization;

namespace InputFormatterSample.Inputformatters
{
    public class CsvInputFormatter : TextInputFormatter
    {
        public CsvInputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }
        protected override bool CanReadType(Type type)
        {
            if (typeof(IEnumerable<Person>).IsAssignableFrom(type) || typeof(Person).IsAssignableFrom(type))
            {
                return base.CanReadType(type);
            }
            return false;
        }
        public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context, Encoding encoding)
        {
            var serviceProvider = context.HttpContext.RequestServices;
            var logger = serviceProvider.GetService(typeof(ILogger<CsvInputFormatter>)) as ILogger;
            var request = context.HttpContext.Request;
            try
            {
                var configuration = new CsvConfiguration(CultureInfo.InvariantCulture);
                configuration.Delimiter = ",";
                configuration.HasHeaderRecord = true;
                using (var csvReader = new CsvReader(new StreamReader(request.Body), configuration))
                {
                    var persons = csvReader.GetRecords<Person>();
                    return await InputFormatterResult.SuccessAsync(persons.ToList());
                }
            }
            catch (Exception ex)
            {

                logger.LogError(ex.StackTrace);
                return await InputFormatterResult.FailureAsync();
            }
        }
    }
}
