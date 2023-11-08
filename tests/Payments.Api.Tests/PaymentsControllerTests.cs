using Moq;
using System.Net.Http.Json;

namespace Payments.Api.Tests
{
    [TestFixture]
    public class PaymentsControllerTests
    {

        private readonly PaymentApiWebApplicationFactory applicationFactory;
        private readonly MockConfig mockConfig;

        public PaymentsControllerTests()
        {
            this.mockConfig = new MockConfig();
            this.applicationFactory = new PaymentApiWebApplicationFactory(this.mockConfig);
        }

        public HttpClient GetClient()
        {
            return applicationFactory.CreateClient();
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Authorize_Success_Response_Test()
        {

            mockConfig.PaymentsRepository.Setup(m => m.AuthorizeAsync(It.IsAny<string>()))
                .Returns<string>((req) => { 
                    return Task.FromResult($"Mock Success: {req}"); 
                });
            var client = GetClient();

            //var request = new HttpRequestMessage(HttpMethod.Post, "api/Payments/authorize/v1");
            var data = "256358";
            var expected = $"Mock Success: Authorization Successful - {data}";
            var httpContent = JsonContent.Create(data);
            var httpResponse = client.PostAsync("api/Payments/authorize/v1", httpContent).Result;
            Assert.True(httpResponse.IsSuccessStatusCode);
            var actual = httpResponse.Content.ReadAsStringAsync().Result;
            Assert.That(expected, Is.EqualTo(actual));
        }
    }
}