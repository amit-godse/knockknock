using KnockKnock.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace KnockKnock.Service.Concrete
{
    public class ReverseWordsService : IReverseWordsService
    {
        private IReverseWordsLogic Service { get; }

        public ReverseWordsService(IReverseWordsLogic _service)
        {
            Service = _service;
        }

        public string ReverseWord(string input)
        {
            if (input == null)
                return "";

            return Service.GetReverseWords(input);
        }
    }
}