using EvalBackendAz.DAL;
using EvalBackendAz.Repository.Contracts;
using EvalBackendAz.Services;
using EvalBackendAz.Services.Contracts;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices((context, services) =>
    {
        var configuration = context.Configuration;
        services.AddDbContext<EvalBackendAzDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("EvalBackendAZ")));


       


    })
    .Build();

host.Run();
