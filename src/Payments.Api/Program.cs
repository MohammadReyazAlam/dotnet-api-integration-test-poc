using Autofac;
using Autofac.Extensions.DependencyInjection;
using Payments.Api.Business.Services;
using Payments.Api.Integration.Data;
using Payments.Api.Integration.Http;
using System.Reflection.Metadata.Ecma335;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterType<PaymentsRepository>().As<IPaymentsRepository>().SingleInstance().PropertiesAutowired();
    containerBuilder.RegisterType<AuthorizationService>().As<IAuthorizationService>().SingleInstance().PropertiesAutowired();
    containerBuilder.RegisterType<SettlementService>().As<ISettlementService>().SingleInstance().PropertiesAutowired();
    containerBuilder.RegisterType<AuthorizationClient>().As<IAuthorizationClient>().SingleInstance().PropertiesAutowired();
    containerBuilder.RegisterType<SettlementClient>().As<ISettlementClient>().SingleInstance().PropertiesAutowired();
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddSingleton<IPaymentsRepository, PaymentsRepository>();
//builder.Services.AddSingleton<IAuthorizationService, AuthorizationService>();
//builder.Services.AddSingleton<ISettlementService, SettlementService>();
//builder.Services.AddSingleton<IAuthorizationClient, AuthorizationClient>();
//builder.Services.AddSingleton<ISettlementClient, SettlementClient>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


public partial class Program
{

}