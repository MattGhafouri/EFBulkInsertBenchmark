using System;
using System.Text;

namespace BulkInsertLoadTest.Helper
{
    public static class RandomGenerator
    {
        private static readonly Random _random = new Random();

        public static int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }

        public static string RandomString(int size, bool lowerCase = false)
        {
            var builder = new StringBuilder();

            char offset = lowerCase ? 'a' : 'A';
            const int letterOffset = 26;

            for (int i = 0; i < size; i++)
            {
                var @char = (char)_random.Next(offset, offset + letterOffset);
                builder.Append(@char);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }
    }
}
