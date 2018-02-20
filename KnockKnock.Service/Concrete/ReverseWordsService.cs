using KnockKnock.Logic;

namespace KnockKnock.Service.Concrete
{
    public class ReverseWordsService : IReverseWordsService
    {
        public ReverseWordsService(IReverseWordsLogic _service)
        {
            Service = _service;
        }

        private IReverseWordsLogic Service { get; }

        public string ReverseWord(string input)
        {
            if (input == null)
                return "";

            return Service.GetReverseWords(input);
        }
    }
}