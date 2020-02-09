using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class Calculator
    {
        public int Add(string input)
        {
            if (input == "")
                return 0;

            char[] delimiters = new char[] { ',', '\n' };
            string values = input;
            int sum = 0;

            // Check delimiters
            if (input[0] == '/' && input[1] == '/')
            { 
                string[] lines = input.Split('\n');
                var firstLine = lines[0];
                values = lines[1];

                char delimiter = firstLine.ToCharArray(2, 1)[0];
                delimiters = new char[] { delimiters[0], delimiters[1], delimiter };
            }

            string[] numbersString = values.Split(delimiters);

            List<int> invalidNumbers = new List<int>();
            foreach(string numberString in numbersString)
            {
                int.TryParse(numberString, out int number);
                
                if (number < 0)
                {
                    invalidNumbers.Add(number);
                }
                sum += number;
            }

            if (invalidNumbers.Any())
            {
                string message = "Negatives not allowed: {0}";
                string invalidNumbersString = string.Join(',', invalidNumbers);
                message = string.Format(message, invalidNumbersString);
                throw new ArgumentOutOfRangeException(message);
            }
            return sum;
        }
    }

}
