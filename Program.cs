// Cool implementation to showcase Random()'s characteristics when generating passwords.
// shamelessly stolen from https://github.com/rohitg15 :)

namespace randomness.netcore
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Program
    {
        static string charSet = "abcdefghijklmnopqrstuvwxyz0123456789";

        public static string GenerateRandomPassword(int length = 8)
        {
            Random rng = new Random();

            string password = string.Empty;
            for (int i = 0; i < length; ++i)
            {
                int index = rng.Next(0, charSet.Length - 1);
                password += charSet[index];
            }

            return password;
        }

        public static void DoRun(int numPasswords = 10000, int pwLen = 8)
        {
            Dictionary<string, int> table = new Dictionary<string, int>();

            Console.Write($"Generating {pwLen} char: ");

            for (int i = 0; i < numPasswords; ++i)
            {
                var password = GenerateRandomPassword(pwLen);
                table[password] = 1 + (table.ContainsKey(password) ? table[password] : 0);
            }

            Console.WriteLine($"{table.Keys.Count}/{numPasswords} unique passwords");
        }

        static void Main(string[] args)
        {
            int numPasswords = 100000;
            int pwLen = 8;

            for (int i = 0; i < 10; ++i)
            {
                DoRun(numPasswords, pwLen);
            }

        }
    }
}