using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace ApiAcceptanceTests
{
    public class AcceptanceTests
    {
        private static readonly HttpClient Client = new HttpClient();
        public AcceptanceTests()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().Get<AppSettings>();
            Client.BaseAddress = new Uri(configuration.ApiUrl);
            Client.DefaultRequestHeaders.Add(
                "X-Correlation-Id", configuration.XCorrelationId.ToString()
            );
        }

        [Fact]
        public async Task ShouldHaveAHealthCheckUrlThatReturns200OK()
        {
            var request = await Client.GetAsync("/healthz");
            request.StatusCode.Should().Be(HttpStatusCode.OK);
            var body = await request.Content.ReadAsStringAsync();
            body.Should().Be("OK");
        }
    }
}