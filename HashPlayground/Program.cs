namespace HashPlayground
{
    using System;
    using System.Linq;
    using System.Net;
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
            var h0 = 0x67452301;
            var h1 = 0xEFCDAB89;
            var h2 = 0x98BADCFE;
            var h3 = 0x10325476;
            var h4 = 0xC3D2E1F0;
            var numberOfBitsPerChar = 8;

                       
            var message = Encoding.ASCII.GetBytes(input).ToList();
            
            // pre-processing
            message.Add(0x80);

            var m1 = message.Count() * numberOfBitsPerChar;
            for (var i = m1; i % 512 != 448; i+=8)
            {
                message.Add(0x00);
            }
            
            var length_le = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((long)m1));
            message.AddRange(length_le);
            
            // TODO: Need to manage little/big endian
            return string.Empty;

        }

        private static void SwapEndian(ref int val)
        {
            val = (val << 24) | ((val << 8) & 0x00ff0000) |
                  ((val >> 8) & 0x0000ff00) | (val >> 24);
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
