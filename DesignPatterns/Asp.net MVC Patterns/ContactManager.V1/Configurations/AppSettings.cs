namespace ContactManager.V1.Configurations
{
    public class AppSettings
    {
        public string Title { get; set; }
        public string ConnectionString { get; set; }
        public AppSettings(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("ContactManager");
            Title = configuration.GetValue<string>("Title");
        }
    }
}
