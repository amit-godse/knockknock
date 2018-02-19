using System;
using System.Collections.Generic;
using KnockKnock.Common;
using KnockKnock.Logic.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace KnockKnock.Logic.Test
{
    [TestClass]
    public class TokenLogicTests
    {
        //
        // System Under Test
        //

        private TokenLogic _sut;
        private Mock<IConfigurationRoot> _configuration;
        private IConfigurationBuilder _config;

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