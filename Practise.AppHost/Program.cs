var builder = DistributedApplication.CreateBuilder(args);

var sqlServer = builder.AddSqlServer("sqlserver");
var sqlDatabase = sqlServer.AddDatabase("exampledb");

var weatherAPI = builder.AddProject<Projects.WeatherAPI>("WeatherAPI");
var contactAPI = builder.AddProject<Projects.ContactAPI>("ContactAPI")
                        .WithReference(sqlDatabase)
                        .WithReplicas(10);

builder.Build().Run();
