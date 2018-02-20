using System.Collections.Generic;
using System.Text;

namespace KnockKnock.Logic.Concrete
{
    public class ReverseWordsLogic : IReverseWordsLogic
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Reverses the word.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>System.String.</returns>
        public string GetReverseWords(string input)
        {
            if (string.IsNullOrWhiteSpace(input) || input.Length == 1) return input;

            var outString = new StringBuilder();
            var wordStack = new Stack<char>();
            var checkpoint = 0;
            while (checkpoint < input.Length)
            {
                if (input[checkpoint] == ' ')
                {
                    PopStackInBuilder(wordStack, outString);
                    outString.Append(" ");
                }
                else
                {
                    wordStack.Push(input[checkpoint]);
                }

                checkpoint++;
            }

            PopStackInBuilder(wordStack, outString);

            return outString.ToString();
        }

        #endregion Public Methods and Operators

        #region Methods

        /// <summary>
        ///     Pops the stack in builder.
        /// </summary>
        /// <param name="wordStack">The word stack.</param>
        /// <param name="outString">The out string.</param>
        private static void PopStackInBuilder(Stack<char> wordStack, StringBuilder outString)
        {
            while (wordStack.Count > 0) outString.Append(wordStack.Pop());
        }

        #endregion Methods
    }
}