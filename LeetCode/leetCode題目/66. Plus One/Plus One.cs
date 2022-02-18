using System;

namespace Plus_One
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] digits = new int[] { 1, 2, 3 };
            Console.WriteLine(PlusOne(digits));
        }
        public static int[] PlusOne(int[] digits)
        {
            digits[digits.Length - 1] += 1;
            if (digits.Length == 1 && digits[0] == 10)
            {
                int[] ans = new int[2] { 1, 0 };
                return ans;
            }

            for (int i = digits.Length - 1; i >= 0; i--)
            {
                if (Array.Equals(digits[i], 10) && digits[0] != 10)
                {
                    digits[i] = 0;
                    digits[i - 1] += 1;
                }
            }
            if (digits[0] == 10)
            {
                int[] ans = new int[digits.Length + 1];
                digits[0] = 0;
                ans[0] = 1;
                Array.Copy(ans, 1, digits, 0, digits.Length - 1);
                return ans;
            }
            return digits;
        }
    }
}
