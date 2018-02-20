using System;
using KnockKnock.Common;
using KnockKnock.Logic.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KnockKnock.Logic.Test
{
    [TestClass]
    public class ShapeFinderLogicTest
    {
        //
        // System Under Test
        //

        private ShapeFinderLogic _sut;

        [TestInitialize]
        public void Setup()
        {
            _sut = new ShapeFinderLogic();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _sut = null;
        }

        [TestMethod]
        [TestCategory("ShapeFinderLogic")]
        public void When_Input_Is_Valid_Should_Return_Results()
        {
            //assemble
            Tuple<int, int, int, ShapeType>[] data =
            {
                new Tuple<int, int, int, ShapeType>(0, 0, 0, ShapeType.Error),
                new Tuple<int, int, int, ShapeType>(-10, -10, -10, ShapeType.Error),
                new Tuple<int, int, int, ShapeType>(0, -10, -10, ShapeType.Error),
                new Tuple<int, int, int, ShapeType>(30, 15, 10, ShapeType.Error),
                new Tuple<int, int, int, ShapeType>(10, 20, 5, ShapeType.Error),
                new Tuple<int, int, int, ShapeType>(10, 10, 10, ShapeType.Equilateral),
                new Tuple<int, int, int, ShapeType>(10, 10, 15, ShapeType.Isosceles),
                new Tuple<int, int, int, ShapeType>(15, 10, 10, ShapeType.Isosceles),
                new Tuple<int, int, int, ShapeType>(10, 12, 8, ShapeType.Scalene),
                new Tuple<int, int, int, ShapeType>(9, 10, 11, ShapeType.Scalene)
            };

            //act
            foreach (var tuple in data)
            {
                var result = _sut.GetShape(tuple.Item1, tuple.Item2, tuple.Item3);

                //assert
                Assert.AreEqual(result, tuple.Item4);
            }
        }
    }
}