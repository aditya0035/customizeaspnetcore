using CustomDISample.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomDISample.Services
{
    public class ServiceA : IService
    {
        public string Message()
        {
            return "Message";
        }
    }
}
