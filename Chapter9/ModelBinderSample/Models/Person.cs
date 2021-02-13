using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModelBinderSample.ModelBinders;

namespace ModelBinderSample.Models
{
    
    public class Person
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Addesss { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
    }
}
