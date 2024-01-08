using Microsoft.Extensions.Configuration;

namespace HumanforceAutomation
{
    public static class ConfigurationHelper
    {

        public static TestSettings GetTestSettings()
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string basePath = Path.Combine(currentDirectory, "..", "..","..");

            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("AppSettings.json")
                .Build();

            var testSettings = new TestSettings();
            configuration.GetSection("TestSettings").Bind(testSettings);

            return testSettings;
        }
    }
}
