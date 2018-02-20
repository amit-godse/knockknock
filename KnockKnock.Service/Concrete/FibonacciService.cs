using System;
using KnockKnock.Logic;

namespace KnockKnock.Service.Concrete
{
    public class FibonacciService : IFibonacciService
    {
        public FibonacciService(IFibonacciLogic _service)
        {
            Service = _service;
        }

        private IFibonacciLogic Service { get; }

        public long GetFibonacciNumberAtPosition(string n)
        {
            long number = 0;
            if (!long.TryParse(n, out number)) throw new InvalidCastException();
            if (Math.Abs(number) > 92) throw new ArgumentOutOfRangeException(nameof(n));

            return Service.FindFibonacciNumberAtPosition(number);
        }
    }
}