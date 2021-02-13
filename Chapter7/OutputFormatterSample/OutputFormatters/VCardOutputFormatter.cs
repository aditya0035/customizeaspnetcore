using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using OutputFormatterSample.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutputFormatterSample.OutputFormatters
{
    public class VCardOutputFormatter : TextOutputFormatter
    {
        public VCardOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/vcard"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }
        protected override bool CanWriteType(Type type)
        {
            if (typeof(Person).IsAssignableFrom(type) || typeof(IEnumerable<Person>).IsAssignableFrom(type))
            {
                return base.CanWriteType(type);
            }
            else
            {
                return false;
            }
        }
        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var serviceProvider = context.HttpContext.RequestServices;
            var logger = serviceProvider.GetService(typeof(ILogger<VCardOutputFormatter>)) as ILogger;
            var response = context.HttpContext.Response;
            var buffer = new StringBuilder();
            if (context.Object is IEnumerable<Person>)
            {
                foreach (var person in context.Object as IEnumerable<Person>)
                {
                    FormateVCard(buffer, person, logger);
                }
            }
            else
            {
                var person = context.Object as Person;
                FormateVCard(buffer, person, logger);
            }
            return response.WriteAsync(buffer.ToString());
        }

        private void FormateVCard(StringBuilder buffer, Person person, ILogger logger)
        {
            buffer.AppendLine("BEGIN:VCARD");
            buffer.AppendLine("VERSION:2.1");
            buffer.AppendLine($"FN:{person.FName} {person.LName}");
            buffer.AppendLine($"N:{person.LName};{person.FName}");
            buffer.AppendLine($"EMAIL:{person.Email}");
            buffer.AppendLine($"TEL;TYPE=VOICE,HOME:{person.Phone}");
            buffer.AppendLine("END:VCARD");
            logger.LogInformation($"writing {person.FName}{person.LName} ");
        }
    }
}
