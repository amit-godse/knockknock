using System;
using KnockKnock.Logic;
using KnockKnock.Service.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace KnockKnock.Service.Test
{
    [TestClass]
    public class TokenServiceTest
    {
        private Mock<ITokenLogic> _logic;
        //
        // System Under Test
        //

        private TokenService _sut;

        [TestInitialize]
        public void Setup()
        {
            _logic = new Mock<ITokenLogic>();
            _logic.Setup(m => m.GetToken())
                .Returns(It.IsAny<Guid>());

            _sut = new TokenService(_logic.Object);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _sut = null;
            _logic = null;
        }

        [TestMethod]
        public void GetToken_WhenCalled_ThenService_Called_Ones()
        {
            //act
            var result = _sut.GetToken();

            //varify
            _logic.Verify(m => m.GetToken(), Times.Once);
        }
    }
}