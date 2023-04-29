

var builder = WebApplication.CreateBuilder(args);
var app = builder
    .ConfigureServices()
    .ConfigurePipeline();

// Uncomment to reset database everytime application is run
await app.ResetDatabaseAsync();

app.Run();
