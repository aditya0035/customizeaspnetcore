using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace OutputFormatterSample.Controllers
{
    [DataContract]
    public class Person
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string FName { get; set; }
        [DataMember]
        public string LName { get; set; }
        [DataMember]
        public int Age { get; set; }
        [JsonIgnore]
        public string Email { get; set; }
        [DataMember]
        public string Addesss { get; set; }
        [DataMember]
        public string City { get; set; }
        [JsonIgnore]
        public string Phone { get; set; }
    }
}