var builder = DistributedApplication.CreateBuilder(args);

var sqlServer = builder.AddSqlServer("sqlserver");
var sqlDatabase = sqlServer.AddDatabase("exampledb");

var weatherAPI = builder.AddProject<Projects.WeatherAPI>("WeatherAPI");
var contactAPI = builder.AddProject<Projects.ContactAPI>("ContactAPI")
                        .WithReference(sqlDatabase)
                        .WithReplicas(2);

builder.AddProject<Projects.Blazor_WASM_App>("BlazorWebAssemplyApp")
       .WithReference(weatherAPI)
       .WithReference(contactAPI);

builder.Build().Run();
