var builder = DistributedApplication.CreateBuilder(args);

var sqlite = builder.AddSqlite("sqlite");

builder.AddProject<Projects.MedicalIS_WebApi>("medicalis-webapi")
    .WithReference(sqlite);

builder.Build().Run();
