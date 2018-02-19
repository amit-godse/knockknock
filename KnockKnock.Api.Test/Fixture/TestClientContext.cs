using Microsoft.AspNetCore.Hosting;
using System.Net.Http;
using Microsoft.AspNetCore.TestHost;
using knockknock;

namespace KnockKnock.Api.Test.Fixture
{
    public class TestClientContext
    {
        private TestServer _server;
        public HttpClient Client { get; private set; }

        public TestClientContext()
        {
            SetUpClient();
        }

        private void SetUpClient()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());

            Client = _server.CreateClient();
        }
    }
}