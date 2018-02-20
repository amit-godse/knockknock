using System;
using KnockKnock.Logic.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KnockKnock.Logic.Test
{
    [TestClass]
    public class ReserveWordsLogicTest
    {
        //
        // System Under Test
        //

        private ReverseWordsLogic _sut;

        [TestInitialize]
        public void Setup()
        {
            _sut = new ReverseWordsLogic();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _sut = null;
        }

        [TestMethod]
        [TestCategory("ReverseWord")]
        public void When_Input_Is_Valid_Should_Return_Valid_Results()
        {
            //assemble
            Tuple<string, string>[] data;
            data = new[] {
                new Tuple<string, string>("", ""),
                new Tuple<string, string>("This is reverse string", "sihT si esrever gnirts"),
                new Tuple<string, string>("knockknock", "kconkkconk"),
                new Tuple<string, string>(null, null)
            };

            //act
            foreach (var tuple in data)
            {
                var result = _sut.GetReverseWords(tuple.Item1);

                //assert
                Assert.AreEqual(result, tuple.Item2);
            }
        }
    }
}