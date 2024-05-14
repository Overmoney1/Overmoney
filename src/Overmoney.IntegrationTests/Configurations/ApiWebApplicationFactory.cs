﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Overmoney.DataAccess;

namespace Overmoney.IntegrationTests.Configurations;
internal class ApiWebApplicationFactory : WebApplicationFactory<Program>
{
    private readonly int _postgresPort;
    private readonly string _postgresHostname;

    public ApiWebApplicationFactory(string hostname, int postgresPort)
    {
        _postgresPort = postgresPort;
        _postgresHostname = hostname;
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            var dbContext = services.FirstOrDefault(x => x.ServiceType.Name.Contains("Context"));
            if (dbContext is not null)
            {
                services.Remove(dbContext);
            }

            var dbContextOptions = services.FirstOrDefault(x => x.ServiceType.Name.Contains("ContextOptions"));
            if (dbContextOptions is not null)
            {
                services.Remove(dbContextOptions);
            }

            services.AddDataAccess($"Host={_postgresHostname}:{_postgresPort};Database=overmoney;Username=dev;Password=dev;Timeout=300;CommandTimeout=300", applyMigrations: true);
        });
    }
}
