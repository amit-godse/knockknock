using System;
using System.Collections.Generic;
using System.Text;

namespace KnockKnock.Service
{
    public interface IFibonacciService
    {
        long GetFibonacciNumberAtPosition(string n);
    }
}