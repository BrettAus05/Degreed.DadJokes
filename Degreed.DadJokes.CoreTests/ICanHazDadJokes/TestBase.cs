using Degreed.DadJokes.Core.ICanHazDadJoke;
using Moq;
using Moq.Protected;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Degreed.DadJokes.CoreTests.ICanHazDadJokes
{
    public class TestBase
    {
        private Mock<HttpMessageHandler> _handlerMock;
        public HttpClient InitiateMockHttpClient(ICanHazDadJokeSettings settings, string content)
        {
            // source - https://gingter.org/2018/07/26/how-to-mock-httpclient-in-your-net-c-unit-tests/

            _handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);

            _handlerMock.Protected()
                // Setup the PROTECTED method to mock
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                // prepare the expected response of the mocked http call
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(content),
                })
                .Verifiable();

            // use real http client with mocked handler here
            var httpClient = new HttpClient(_handlerMock.Object)
            {
                BaseAddress = new Uri(settings.Uri),
            };

            return httpClient;
        }
    }
}
