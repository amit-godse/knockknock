using KnockKnock.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace KnockKnock.Service.Concrete
{
    public class FibonacciService : IFibonacciService
    {
        private IFibonacciLogic Service { get; }

        public FibonacciService(IFibonacciLogic _service)
        {
            Service = _service;
        }

        public long GetFibonacciNumberAtPosition(string n)
        {
            long number = 0;
            if (!long.TryParse(n, out number))
            {
                throw new InvalidCastException();
            }
            if (Math.Abs(number) > 92)
            {
                throw new ArgumentOutOfRangeException(nameof(n));
            }

            return Service.FindFibonacciNumberAtPosition(number);
        }
    }
}