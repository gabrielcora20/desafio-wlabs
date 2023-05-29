using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Serilog;
using Wlabs.Services.Core.Middleware;

namespace Wlabs.Services.Core.Configurations
{
    public static class ApiConfig
    {
        public static void UseApiConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSerilogRequestLogging(opts => opts.EnrichDiagnosticContext = SerilogConfig.EnrichFromRequest);

            app.UseMiddleware<RequestSerilLogMiddleware>();
            app.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
