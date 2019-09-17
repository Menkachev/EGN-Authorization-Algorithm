namespace EgnAlgorithm
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        public static void Main(string[] args)
        {
            string egn = Console.ReadLine();

            Console.WriteLine(egnAuthorization(egn));
        }

        private static string egnAuthorization(string egn)
        {
            long input;

            bool validInput = long.TryParse(egn, out input);

            if (input != 0)
            {
                var inputArray = digitArr(input);
                if (inputArray.Length < 10)
                {
                    return ErrorService.lessThanTenDigitsError();
                }

                if (inputArray.Length > 10)
                {
                    return ErrorService.moreThanTenDigitsError();
                }
            }
            else
            {
                return ErrorService.invalidInputError();
            }

            return IsValid(input);
        }

        // Check if the EGN is valid
        private static string IsValid(long input)
        {
            long lastNumber = input % 10;
            long numbersToCheck = input / 10;

            var arr = digitArr(numbersToCheck);
            var arrsResult = controlNumberCalculation(arr);

            var divideByEleven = (long)arrsResult / 11;
            var controlNumber = (long)arrsResult - divideByEleven * 11;

            if (controlNumber >= 10)
            {
                controlNumber = 0;
            }

            if (controlNumber == lastNumber)
            {
                return ValidationService.validEgn();
            }
            else
            {
                return ErrorService.invalidEgnError();
            }
        }

        // Calculate the control number(last digit of the EGN)
        private static object controlNumberCalculation(long[] egnDigits)
        {
            // Position: 1	2	3	4	5	6	7	8	9
            // Weight:   2  4   8   5   10  9   7   3   6
            long[] weightNumbers = { 2, 4, 8, 5, 10, 9, 7, 3, 6 };
            List<long> arrsMultiplyResult = new List<long>();

            // Multiply EGN numbers with the Weight numbers
            for (int i = 0; i < egnDigits.Length; i++)
            {
                var sum = egnDigits[i] * weightNumbers[i];
                arrsMultiplyResult.Add(sum);
            }

            long result = 0;
            // Sum the results of the multiply
            for (int i = 0; i < arrsMultiplyResult.Count; i++)
            {
                result += arrsMultiplyResult[i];
            }

            return result;
        }

        // Convert long digit into array of digits
        public static long[] digitArr(long n)
        {
            if (n == 0) return new long[1] { 0 };

            var digits = new List<long>();

            for (; n != 0; n /= 10)
                digits.Add(n % 10);

            var arr = digits.ToArray();
            Array.Reverse(arr);
            return arr;
        }
    }
}