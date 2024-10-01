var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/", () => System.Environment.GetEnvironmentVariable("MY_GATEWAY"));

app.Run();
