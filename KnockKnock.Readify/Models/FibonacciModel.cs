using System;

namespace KnockKnock.Readify.Models
{
    public class FibonacciModel
    {
        public long GenerateFibonacciNumber(int position)
        {
            //Source https://en.wikipedia.org/wiki/Fibonacci_number
            if (position >= 0)
            {
                var result =  Math.Pow( (1+ Math.Sqrt(5.0))/2, position) / Math.Sqrt(5.0);
                var roundedValue = Math.Round(result);
                return (long)roundedValue;
            }
            else
            {
                return Math.Abs(position) % 2 == 0 ? -GenerateFibonacciNumber(Math.Abs(position)) : GenerateFibonacciNumber(Math.Abs(position));
            }
        }
    }
}