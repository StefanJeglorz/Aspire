var builder = DistributedApplication.CreateBuilder(args);

var weatherAPI = builder.AddProject<Projects.WeatherAPI>("WeatherAPI");

builder.Build().Run();
