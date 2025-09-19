using System.Text;
using System.Text.RegularExpressions;

namespace BigNumberPZ1
{
    public struct BigNumber
    {
        private const char Zero = '0';
        private const char Plus = '+';
        private const char Minus = '-';
        private const int MaxCountOfDigitsInInt = 9;
        private readonly int[] _digits;

        public bool IsNegative { get; }

        public BigNumber(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                throw new ArgumentException("Number was null or whitespace!", nameof(number));
            }

            var trimmedNumberSpan = number.AsSpan().Trim();
            if (!Regex.IsMatch(trimmedNumberSpan, @"^[-+]?\d+$"))
            {
                throw new ArgumentException("The number must consist of the + and - signs at the beginning and numbers after them!", nameof(number));
            }

            IsNegative = (number[0] == Minus) ? true : false;
            var capacity = (int)Math.Ceiling((double)number.Length / MaxCountOfDigitsInInt);
            _digits = new int[capacity];

            for (int i = trimmedNumberSpan.Length - 1, counter = capacity - 1;  i >= 0; --counter)
            {
                var length = Math.Min(MaxCountOfDigitsInInt, i);
                var start = (length == MaxCountOfDigitsInInt) ? i - MaxCountOfDigitsInInt  : 0;

                var digitSpan = trimmedNumberSpan.Slice(start, length);
                var digit = int.Parse(digitSpan);
                _digits[counter] = digit;

                if (i >= MaxCountOfDigitsInInt)
                {
                    i -= MaxCountOfDigitsInInt;
                }
                else
                {
                    break;
                }
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            if (IsNegative)
            {
                builder.Append(Minus);
            }

            for (int i = 0; i < _digits.Length; ++i)
            {
                builder.Append(_digits[i]);
            }
            return builder.ToString();
        }

        public readonly ReadOnlySpan<int> Digits => _digits.AsSpan();

        public static BigNumber operator +(BigNumber a, BigNumber b)
        {
            var aDigits = a.Digits;
            var bDigits = b.Digits;
            

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

        //public static BigNumber Pow(BigNumber value, long degree)
        //{
        //    return value + degree;
        //}
    }
}
