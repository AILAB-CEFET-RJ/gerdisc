namespace gerdisc.Settings
{
    public class Settings
    {
        public IConfigurationRoot config { get; }
        public Settings()
        {
            config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
        }
    }
}