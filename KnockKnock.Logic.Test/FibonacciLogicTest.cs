using System;
using System.Collections.Generic;
using KnockKnock.Logic.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KnockKnock.Logic.Test
{
    [TestClass]
    public class FibonacciLogicTest
    {
        //
        // System Under Test
        //

        private FibonacciLogic _sut;

        [TestInitialize]
        public void Setup()
        {
            _sut = new FibonacciLogic();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _sut = null;
        }

        [TestMethod]
        [TestCategory("FibonacciLogic")]
        public void When_Input_Is_Valid_Return_Success()
        {
            //assemble
            var data = new List<Tuple<long, long>>
            {
                new Tuple<long, long>(0, 0),
                new Tuple<long, long>(-1, 1),
                new Tuple<long, long>(1, 1),
                new Tuple<long, long>(15, 610),
                new Tuple<long, long>(11, 89),
                new Tuple<long, long>(-11, 89)
            };

            //act
            foreach (var tuple in data)
            {
                var result = _sut.FindFibonacciNumberAtPosition(tuple.Item1);

                //Assert
                Assert.AreEqual(tuple.Item2, result);
            }
        }
    }
}