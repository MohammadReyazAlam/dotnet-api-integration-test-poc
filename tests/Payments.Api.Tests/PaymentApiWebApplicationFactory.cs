using Autofac;
using FluentAssertions.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Payments.Api.Integration.Data;
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

        protected override IHost CreateHost(IHostBuilder builder)
        {
            //builder.UseDefaultServiceProvider
            builder.ConfigureContainer<ContainerBuilder>(ConfiguresContainer);
            return base.CreateHost(builder);
        }

        private void ConfiguresContainer(HostBuilderContext context, ContainerBuilder builder)
        {
            //builder.Register((p)=> mockConfig.PaymentsRepository.Object).As().SingleInstance().PropertiesAutowired();

            foreach ((var interfaceType, var mockObject) in mockConfig.GetMocks())
            {
                builder.Register((p) => mockObject).As(interfaceType).SingleInstance().PropertiesAutowired();
            }
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            
            builder.UseEnvironment("SDET");
            base.ConfigureWebHost(builder);
            builder.ConfigureServices(services => { 
                foreach ((var interfaceType, var mockObject) in mockConfig.GetMocks())
                {
                    var service = services.SingleOrDefault(s => s.ServiceType == interfaceType);
                    services.Remove(service);
                    services.AddSingleton(interfaceType, mockObject);
                }
            });
        }
    }
}
