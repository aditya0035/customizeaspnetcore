using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace ConfigurationSample
{
    public class YamlConfigurationProvider : FileConfigurationProvider
    {
        private YamlConfigurationSource _source;

        public YamlConfigurationProvider(YamlConfigurationSource source):base(source)
        {
            _source = source;
        }

        public override void Load(Stream stream)
        {
            var parser = new YamlConfigurationFileParser();
            Data = parser.Parse(stream);
        }
    }
}