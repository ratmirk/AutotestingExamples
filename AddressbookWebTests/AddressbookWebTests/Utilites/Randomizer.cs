using System;
using System.Text;

namespace AddressbookWebTests
{
    public static class Randomizer
    {
        private static Random _random;
        private static Random Random => _random ?? (_random = new Random());

        public static string GenerateRandomString(int maxLength)
        {
            var length = Random.Next(0, maxLength);

            var builder = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                builder.Append(Convert.ToChar((Random.Next(65, 125))));
            }

            return builder.ToString();
        }
    }
}
