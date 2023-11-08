using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Api.Tests
{
    internal class PaymentApiWebApplicationFactory : WebApplicationFactory<Program>
    {
        private readonly MockConfig mockConfig;

        internal PaymentApiWebApplicationFactory(MockConfig mockConfig)
        {
            this.mockConfig = mockConfig;
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("SDET");
            base.ConfigureWebHost(builder);
            builder.ConfigureServices(services => { 
                foreach ((var interfaceType, var mockObject) in mockConfig.GetMocks())
                {
                    services.Remove(services.SingleOrDefault(s => s.ServiceType == interfaceType));
                    services.AddSingleton(interfaceType, mockObject);
                }
            });
        }
    }
}
