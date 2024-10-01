var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddCors();

builder.Services
    .AddHttpClient("Fusion");

var gatewayBuilder = builder.Services
    .AddFusionGatewayServer()
    .ConfigureFromFile("./gateway.fgp")
    .AddServiceDiscoveryRewriter();

var app = builder.Build();

app.UseWebSockets();
app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.MapGraphQL();

app.RunWithGraphQLCommands(args);
