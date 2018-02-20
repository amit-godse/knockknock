using System;
using KnockKnock.Logic;
using KnockKnock.Service.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace KnockKnock.Service.Test
{
    [TestClass]
    public class FibonacciServiceTest
    {
        private Mock<IFibonacciLogic> _logic;
        //
        // System under test
        //

        private FibonacciService _sut;

        [TestInitialize]
        public void Setup()
        {
            _sut = null;
        }

        [TestCleanup]
        public void CleanUp()
        {
            _logic = null;
            _sut = null;
        }

        [TestMethod]
        public void GetFibonacciNumberAtPosition_WhenValid_ServiceCalled_Ones()
        {
            //assemble
            _logic = new Mock<IFibonacciLogic>();
            _logic.Setup(logic => logic.FindFibonacciNumberAtPosition(It.IsAny<long>()))
                .Returns(It.IsAny<long>());

            _sut = new FibonacciService(_logic.Object);
            long expected = 9;

            //act
            var result = _sut.GetFibonacciNumberAtPosition(expected.ToString());

            //assert
            _logic.Verify(m => m.FindFibonacciNumberAtPosition(It.Is<long>(input => input == expected)), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public void GetFibonacciNumberAtPosition_WhenInvalid_ServiceCalled_Never()
        {
            try
            {
                //assemble
                _logic = new Mock<IFibonacciLogic>();
                _logic.Setup(logic => logic.FindFibonacciNumberAtPosition(It.IsAny<long>()))
                    .Returns(It.IsAny<long>());

                _sut = new FibonacciService(_logic.Object);
                var expected = "x";

                //act
                var result = _sut.GetFibonacciNumberAtPosition(expected);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                //assert
                _logic.Verify(m => m.FindFibonacciNumberAtPosition(It.IsAny<long>()), Times.Never);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetFibonacciNumberAtPosition_WhenNumberIsGreaterThan92_ServiceCalled_Never_WithException()
        {
            try
            {
                //assemble
                _logic = new Mock<IFibonacciLogic>();
                _logic.Setup(logic => logic.FindFibonacciNumberAtPosition(It.IsAny<long>()))
                    .Returns(It.IsAny<long>());

                _sut = new FibonacciService(_logic.Object);
                long expected = 93;

                //act
                var result = _sut.GetFibonacciNumberAtPosition(expected.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                //assert
                _logic.Verify(m => m.FindFibonacciNumberAtPosition(It.IsAny<long>()), Times.Never);
            }
        }
    }
}