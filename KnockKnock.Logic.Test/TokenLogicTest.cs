using System;
using KnockKnock.Logic.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace KnockKnock.Logic.Test
{
    [TestClass]
    public class TokenLogicTests
    {
        private IConfigurationBuilder _config;

        private Mock<IConfigurationRoot> _configuration;
        //
        // System Under Test
        //

        private TokenLogic _sut;

        [TestInitialize]
        public void Setup()
        {
        }

        [TestCleanup]
        public void Cleanup()
        {
            _sut = null;
        }

        [TestMethod]
        [TestCategory("ShapeFinderLogic")]
        public void Should_Return_Matching_Token()
        {
            //assemble
            var expected = Guid.NewGuid();
            _configuration = new Mock<IConfigurationRoot>();
            _configuration.SetupGet(x => x[It.IsAny<string>()]).Returns(expected.ToString());

            _sut = new TokenLogic(_configuration.Object);

            //act
            var result = _sut.GetToken();

            Assert.AreEqual(result, expected);
        }
    }
}