namespace Randomness
{
    // Cool implementation to showcase Random()'s characteristics when generating passwords.
    // shamelessly stolen from https://github.com/rohitg15 :)

    using System;
    using System.Collections.Generic;

    class Program
    {
        static string charSet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

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

            Console.Write("{0,2} chars: ", pwLen);

            for (int i = 0; i < numPasswords; ++i)
            {
                var password = GenerateRandomPassword(pwLen);
                table[password] = 1 + (table.ContainsKey(password) ? table[password] : 0);
            }

            Console.WriteLine($"{table.Keys.Count}/{numPasswords} unique passwords");
        }

        static void Main(string[] args)
        {
            int numPasswords = 10000;
            int pwLen = 8;
            int maxpwLen = 16;

            Console.WriteLine($".NET random() password generator");
            for (int i = pwLen; i <= maxpwLen; ++i)
            {
                DoRun(numPasswords, i);
            }
            Console.ReadKey();
        }
    }

}



