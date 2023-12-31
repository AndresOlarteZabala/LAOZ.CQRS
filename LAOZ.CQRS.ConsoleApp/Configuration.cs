using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

namespace LAOZ.CQRS.ConsoleApp
{
    public class Configuration : IConfiguration
    {
        private readonly Dictionary<string, string> _configurations;

        public Configuration() {
            IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();

            _configurations = GetConfigurationAsDictionary(configuration);
        }
        public Configuration(Dictionary<string, string> configurations)
        {
            _configurations = configurations ?? throw new ArgumentNullException(nameof(configurations));
        }

        public string this[string key]
        {
            get => _configurations.TryGetValue(key, out var value) ? value : null;
            set => _configurations[key] = value;
        }

        public IEnumerable<IConfigurationSection> GetChildren() => throw new NotImplementedException();

        public IChangeToken GetReloadToken() => throw new NotImplementedException();

        public IConfigurationSection GetSection(string key) => throw new NotImplementedException();
        
        static Dictionary<string, string> GetConfigurationAsDictionary(IConfiguration configuration)
        {
            Dictionary<string, string> result = [];
            FlattenConfiguration(configuration, result);
            return result;
        }

        static void FlattenConfiguration(IConfiguration configuration, Dictionary<string, string> result, string parentKey = "")
        {
            foreach (var child in configuration.GetChildren())
            {
                var key = string.IsNullOrEmpty(parentKey)
                    ? child.Key
                    : $"{parentKey}:{child.Key}";

                if (child.GetChildren().Any())
                {
                    FlattenConfiguration(child, result, key);
                }
                else
                {
                    result[key] = child.Value;
                }
            }
        }
    }
}
