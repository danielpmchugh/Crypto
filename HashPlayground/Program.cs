namespace HashPlayground
{
    using System;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    class Program
    {
        static void Main(string[] args)
        {

            var length = (int)new Random().Next() % 1000000;
            var input = RandomString(length);
            var myOutput = MySha1(input);
            var correctOutput = MsftSha1(input);
            Console.WriteLine($"Input (first 50)(actual {length}: {input.Substring(0, 50 < length ? 50 : length-1)}");
            Console.WriteLine($"Match: {myOutput == correctOutput}");
            Console.WriteLine($"My Sha1: {myOutput}");
            Console.WriteLine($"Correct Sha1 {correctOutput}");
        }

        private static string MySha1(string input)
        {
            return string.Empty;
        }

        private static string MsftSha1(string input)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    // can be "x2" if you want lowercase
                    sb.Append(b.ToString("X2"));
                }

                return sb.ToString();
            }
        }
        
        private static string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
