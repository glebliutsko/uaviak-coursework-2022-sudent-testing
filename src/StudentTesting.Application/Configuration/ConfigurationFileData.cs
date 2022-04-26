using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace StudentTesting.Application.Configuration
{
    public class ConfigurationData
    {
        [JsonPropertyName("db")]
        [Required]
        public DatabaseConfigurationData Database { get; set; }
    }

    public class DatabaseConfigurationData
    {
        [Required]
        public string Address { get; set; }
        [Required]
        public string Name { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
    }
}
