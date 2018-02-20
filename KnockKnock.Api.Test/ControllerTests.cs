using System.Net;
using System.Threading.Tasks;
using KnockKnock.Api.Test.Fixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KnockKnock.Api.Test
{
    [TestClass]
    public class ControllerTests
    {
        //
        // System under test
        //

        private TestClientContext _sut;

        [TestInitialize]
        public void Setup()
        {
            _sut = new TestClientContext();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _sut = null;
        }

        [TestMethod]
        public async Task Fibonacci_Should_Return_Fibonacci_number()
        {
            //act
            var response = await _sut.Client.GetAsync("/api/Fibonacci?n=10");
            var result = response.Content.ReadAsStringAsync().Result;
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(result, "55");
        }


        [TestMethod]
        public async Task ReverseWord_Should_Return_ReverseWords()
        {
            //act
            var response = await _sut.Client.GetAsync("/api/ReverseWords?sentence=is not valid");
            var result = response.Content.ReadAsStringAsync().Result;
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(result, "si ton dilav");
        }


        [TestMethod]
        public async Task GetToken_Should_Return_Token()
        {
            //act
            var response = await _sut.Client.GetAsync("/api/Token");
            var result = response.Content.ReadAsStringAsync().Result;
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public async Task GetShape_Should_Return_Shape()
        {
            //assemble
            var expected = "Equilateral";
            //act
            var response = await _sut.Client.GetAsync("/api/TriangleType?a=10&b=10&c=10");
            var result = response.Content.ReadAsStringAsync().Result;
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(result, expected);
        }
    }
}