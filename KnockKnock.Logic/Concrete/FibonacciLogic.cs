using System;

namespace KnockKnock.Logic.Concrete
{
    public class FibonacciLogic : IFibonacciLogic
    {
        public long FindFibonacciNumberAtPosition(long input)
        {
            var absoluteValue = Math.Abs(input);
            switch (input)
            {
                case 0:
                    return 0;

                case 1:
                    return 1;

                case -1:
                    return 1;
            }

            long stackTop = 1, stackLow = 0;
            for (long counter = 2; counter <= absoluteValue; counter++)
            {
                var topValue = stackTop + stackLow;
                stackLow = stackTop;
                stackTop = topValue;
            }

            if (input < 0 && input % 2 == 0) return stackTop * -1;

            return stackTop;
        }
    }
}