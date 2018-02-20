using KnockKnock.Logic;
using KnockKnock.Service.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace KnockKnock.Service.Test
{
    [TestClass]
    public class ReverseWordServiceTest
    {
        private Mock<IReverseWordsLogic> _logic;
        //
        // System Under Test
        //

        private ReverseWordsService _sut;

        [TestInitialize]
        public void Setup()
        {
            _logic = new Mock<IReverseWordsLogic>();
            _logic.Setup(m => m.GetReverseWords(It.IsAny<string>()))
                .Returns(It.IsAny<string>());

            _sut = new ReverseWordsService(_logic.Object);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _sut = null;
            _logic = null;
        }

        [TestMethod]
        public void GetReverseWords_WhenValidInput_CallService_Ones()
        {
            //assemble
            var expected = "words to reverse";

            //act
            var result = _sut.ReverseWord(expected);

            //varify
            _logic.Verify(m => m.GetReverseWords(It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void GetReverseWords_WhenInValidInput_CallService_Never()
        {
            //act
            var result = _sut.ReverseWord(null);

            //varify
            _logic.Verify(m => m.GetReverseWords(It.IsAny<string>()), Times.Never);
        }
    }
}