using System;
using System.Linq;

namespace Tests.Console.BunchRequestsSender.Helpers
{
    internal static class Randomizer
    {
        private static Random random = new Random();

        public static string String =>
            RandomString();

        public static string RandomString(int length = 8)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static int Int =>
            RandomInt();

        public static int RandomInt(int min = int.MinValue, int max = int.MaxValue)
        {
            unchecked
            {
                int firstBits = random.Next(0, 1 << 4) << 28;
                int lastBits = random.Next(0, 1 << 28);
                var result = firstBits | lastBits;
                return result >= min && result <= max ? result : RandomInt(min, max);
            }
        }

        public static decimal Decimal =>
            RandomDecimal();

        public static decimal RandomDecimal(decimal min = decimal.MinValue, decimal max = decimal.MaxValue)
        {
            byte scale = (byte)random.Next(29);
            bool sign = random.Next(2) == 1;

            var result = new decimal(RandomInt(),
                               RandomInt(),
                               RandomInt(),
                               sign,
                               scale);
            return result >= min && result <= max ? result : RandomDecimal(min, max);
        }

        public static Tuple<decimal, decimal> RandomKenyaLocation()
        {
            var longitude = RandomDecimal(34, 42);
            var latitude = RandomDecimal(-4, 4);
            return new Tuple<decimal, decimal>(latitude, longitude);
        }
    }
}