using System;
using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (String.IsNullOrEmpty(numbers)) return 0;
            //var result = numbers.Split(',').Select(s => int.Parse(s)).Sum();


            var numberList = numbers.Split(',').ToArray().Select(s => int.Parse(s));
            var negatives = numberList.Where(n => n < 0);

            if(negatives.Any())
            {
                string negativeString = String.Join(',', negatives.Select(n => n.ToString()));
                throw new Exception($"Negatives not allowed: {negativeString}");
            }

            var result = numberList.Where(n=> n <= 1000).Sum();

            return result;
        }
    }
}
