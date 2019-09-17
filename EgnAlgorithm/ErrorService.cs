using System;
using System.Collections.Generic;
using System.Text;

namespace EgnAlgorithm
{
    public class ErrorService
    {
        public static string moreThanTenDigitsError()
        {
           return "Invalid input! Please enter no more or less than ten digits!";
        }

        public static string lessThanTenDigitsError()
        {
            return "Invalid input! Please enter not less and no more than ten digits!";
        }

        public static string invalidInputError()
        {
            return "Invalid input! Please enter digits only.";
        }

        public static string invalidEgnError()
        {
            return "Invalid EGN! Please try again.";
        }
    }
}