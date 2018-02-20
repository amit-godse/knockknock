using System;
using KnockKnock.Common;
using KnockKnock.Logic;
using KnockKnock.Service.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace KnockKnock.Service.Test
{
    [TestClass]
    public class TriangleTypeServiceTest
    {
        private Mock<IShapeFinderLogic> _logic;
        //
        // System Under Test
        //

        private TriangleTypeService _sut;

        [TestInitialize]
        public void Setup()
        {
            _logic = new Mock<IShapeFinderLogic>();
            _logic.Setup(m => m.GetShape(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(It.IsAny<ShapeType>());

            _sut = new TriangleTypeService(_logic.Object);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _sut = null;
            _logic = null;
        }

        [TestMethod]
        public void GetShape_WhenCalled_ThenService_Called_Ones()
        {
            //assemble
            string sidea = "10", sideb = "10", sidec = "10";
            //act
            var result = _sut.GetTriangleType(sidea, sideb, sidec);

            //varify
            _logic.Verify(m => m.GetShape(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void GetShape_WhenInvalidCalled_ThenService_Called_Never()
        {
            string sidea = "10", sideb = "xx", sidec = "10";

            //assert
            Assert.ThrowsException<InvalidCastException>(() => _sut.GetTriangleType(sidea, sideb, sidec));

            //varify
            _logic.Verify(m => m.GetShape(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()), Times.Never);
        }
    }
}