using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using ModelBinderSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelBinderSample.ModelBinders
{
    public class PersonModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            if (context.Metadata.ModelType == typeof(Person) || context.Metadata.ModelType == typeof(IEnumerable<Person>))
                return new BinderTypeModelBinder(typeof(PersonModelBinder));
            return null;
        }
    }
}
