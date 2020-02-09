using System;


namespace StringCalculator
{
    public class Calculator
    {
        public int Add(string input)
        {
            if (input == "")
                return 0;

            if (input.Length == 1)
            {
                int.TryParse(input, out int number);
                if (number < 0)
                {
                    string message = "Negatives not allowed: {0}";
                    message = string.Format(message, number);
                    throw new ArgumentOutOfRangeException(message);
                }
                return int.Parse(input);
            }
            char[] delimiters = new char[] { ',', '\n' };
            string values = input;

            if("" + input[0] + input[1] == "//")
            { 
                string[] lines = input.Split('\n');
                var firstLine = lines[0];
                values = lines[1];

                char delimiter = firstLine.ToCharArray(2, 1)[0];
                delimiters = new char[] { delimiters[0], delimiters[1], delimiter };
            }

            string[] numbers = values.Split(delimiters);

            int sum = 0;
            foreach(string number in numbers)
            {
                sum += int.Parse(number);
            }
            return sum;
        }
    }

}
