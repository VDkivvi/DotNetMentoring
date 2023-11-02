using System;
using System.Linq;
using System.Text.RegularExpressions;


namespace Task2
{
    public partial class NumberParser : INumberParser
    {
        public int Parse(string stringValue)
        {
            if (stringValue is null) throw new ArgumentNullException();

            var output = stringValue.Trim();

            if (string.IsNullOrWhiteSpace(output) || SignsOutOfOrder().IsMatch(output)) 
                throw new FormatException($"Bad format: {stringValue}");
            
            var plusMinusTrailingZeros = TrailingChars();
            while (plusMinusTrailingZeros.IsMatch(output))
                output = plusMinusTrailingZeros.Replace(output, "");

            if (output.Length == 0) return 0;

            var sign = stringValue.First() == '-' ? -1 : 1;

            var charsInt = output.Reverse().Select((c, ind) =>
            {
                var power = (int)Math.Pow(Convert.ToDouble(10), Convert.ToDouble(ind));
                return (c - '0') * power;
            });

            var first = charsInt.First() * sign;
            return charsInt.Skip(1).Aggregate(first, (a, b) =>
            {
                var sum = a + sign * b;
                if ((sum ^ sign) < 0)
                    throw new OverflowException($"Not int. {stringValue}.");
                return sum;
            });
        }


        [GeneratedRegex("(^\\++|^-+|^0+| $)")]
        private static partial Regex TrailingChars();

        [GeneratedRegex("([^0-9]{2,})|(\\d(?=[^0-9]))")]
        private static partial Regex SignsOutOfOrder();
    }
}