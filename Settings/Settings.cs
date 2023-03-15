namespace gerdisc.Settings
{
    public class Settings: ISettings
    {
        public IConfigurationRoot config { get; }

        public string SingingKey => config.GetValue<string>("SingingKey")??"";
        public string postgresPort => config.GetValue<string>("postgresPort")??"";
        public string PostgresServer => config.GetValue<string>("PostgresServer")??"";
        public string PostgresUser => config.GetValue<string>("PostgresUser")??"";
        public string PostgresPassword => config.GetValue<string>("PostgresPassword")??"";
        public string PostgresDb => config.GetValue<string>("PostgresDb")??"";
        public Settings()
        {
            config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
        }
    }
}