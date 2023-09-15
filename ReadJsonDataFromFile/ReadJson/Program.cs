// See https://aka.ms/new-console-template for more information

using ReadJson;


IAppConfiguration configuration = new AppConfiguration();

AzureManager manager = new(configuration);
if (manager == null) throw new ArgumentNullException(nameof(manager));

await manager.GetResults();








