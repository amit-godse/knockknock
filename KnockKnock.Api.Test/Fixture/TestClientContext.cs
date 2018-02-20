using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace KnockKnock.Api.Test.Fixture
{
    public class TestClientContext
    {
        private TestServer _server;

        public TestClientContext()
        {
            SetUpClient();
        }

        public HttpClient Client { get; private set; }

        private void SetUpClient()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());

            Client = _server.CreateClient();
        }
    }
}