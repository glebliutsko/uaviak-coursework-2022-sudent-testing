using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace StudentTesting.Application.Configuration
{
    public class Configuration
    {
        private JsonSerializerOptions _options = new JsonSerializerOptions
        {
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        public string AddressDatabase { get; set; }
        public string UsernameDatabase { get; set; }
        public string PasswordDatabase { get; set; }
        public string NameDatabase { get; set; }

        public string Path { get; }
        public bool IsExsist { get; private set; }

        public Configuration(string path)
        {
            Path = path;
            IsExsist = File.Exists(path);

            if (IsExsist)
                ReadConfigFile();
        }

        private void ReadConfigFile()
        {
            string configurationJson = File.ReadAllText(Path);
            ConfigurationData config = JsonSerializer.Deserialize<ConfigurationData>(configurationJson, _options);

            AddressDatabase = config.Database.Address;
            UsernameDatabase = config.Database.Username;
            PasswordDatabase = config.Database.Password;
            NameDatabase = config.Database.Name;
        }

        public void Save() =>
            SaveAs(Path);

        public void SaveAs(string path)
        {
            ConfigurationData config = new()
            {
                Database = new()
                {
                    Address = AddressDatabase,
                    Password = PasswordDatabase,
                    Username = UsernameDatabase,
                    Name = NameDatabase,
                }
            };

            string configurationJson = JsonSerializer.Serialize(config, _options);

            File.WriteAllText(path, configurationJson);
            IsExsist = true;
        }
    }
}
