using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.IO;
using CsvHelper.Configuration;
using System.Globalization;
using CsvHelper;
using ModelBinderSample.Models;

namespace ModelBinderSample.ModelBinders
{
    public class PersonModelBinder : IModelBinder
    {
        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));
            var modelName = bindingContext.ModelName;
            if (string.IsNullOrEmpty(modelName))
            {
                modelName = bindingContext.OriginalModelName;
            }
            var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);
            if (valueProviderResult == ValueProviderResult.None)
                return;
            bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);
            var value = valueProviderResult.FirstValue;
            if (string.IsNullOrEmpty(value))
                return;
            var reader = new StringReader(value);
            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture);
            configuration.Delimiter = ",";
            configuration.HasHeaderRecord = true;
            using (var csvReader=new CsvReader(reader,configuration))
            {
                var result = csvReader.GetRecords<Person>();
                IEnumerable<Person> persons = result.ToList();
                bindingContext.Result =ModelBindingResult.Success(persons);
            }
        }
    }
}
