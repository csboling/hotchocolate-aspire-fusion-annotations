var builder = DistributedApplication.CreateBuilder(args);

var subgraph = builder.AddProject<Projects.Subgraph>("subgraph");
var gateway = builder.AddFusionGateway<Projects.Gateway>("gateway")
    .WithSubgraph(subgraph)
    .WithExternalHttpEndpoints();

// this server will fail to start because it tries to use an endpoint from `gateway`
var downstream = builder.AddProject<Projects.Downstream>("downstream")
    .WithEnvironment("MY_GATEWAY", gateway.GetEndpoint("http"));

builder.Build().Compose().Run();
