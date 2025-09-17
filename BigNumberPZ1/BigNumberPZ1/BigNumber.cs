using System.Text.RegularExpressions;

namespace BigNumberPZ1
{
    public struct BigNumber
    {
        private const char Zero = '0';
        private const char Plus = '+';
        private const char Minus = '-';
        private const int MaxCountOfDigitsInInt = 9;
        private readonly List<int> _digits;

        public bool IsNegative { get; }

        public BigNumber(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                throw new ArgumentException("Number was null or whitespace!", nameof(number));
            }

            var trimmedNumberSpan = number.AsSpan().Trim();
            if (Regex.IsMatch(trimmedNumberSpan, @"^[-+]?\d+$"))
            {
                throw new ArgumentException("The number must consist of the + and - signs at the beginning and numbers after them!", nameof(number));
            }

            IsNegative = (number[0] == Minus) ? true : false;
            var capacity = (int)Math.Ceiling((double)number.Length / MaxCountOfDigitsInInt);
            _digits = new List<int>(capacity);

            for (int i = 0; i < capacity; i++)
            {
                var digitSpan = trimmedNumberSpan.Slice((trimmedNumberSpan.Length - 1) * i, MaxCountOfDigitsInInt);
                var digit = int.Parse(digitSpan);
                _digits.Insert(0, digit);
            }
        }

        public static BigNumber operator +(BigNumber a, BigNumber b)
        {
            return a + b;
        }

        public static BigNumber operator -(BigNumber a, BigNumber b)
        {
            return a + b;
        }


        public static BigNumber operator /(BigNumber a, BigNumber b)
        {
            return a + b;
        }


        public static BigNumber operator *(BigNumber a, BigNumber b)
        {
            return a + b;
        }


        public static BigNumber Pow(BigNumber value, BigNumber degree)
        {
            return value + degree;
        }

        public static BigNumber Pow(BigNumber value, long degree)
        {
            return value + degree;
        }
    }
}
