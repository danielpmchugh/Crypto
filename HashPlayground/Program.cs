namespace HashPlayground
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Please enter the string you wish to hash");
            }
            var input = args[1];
            var output = MySha1(input);
            Console.WriteLine(output);
        }

        static string MySha1(string input)
        {
            throw new NotImplementedException();
        }
    }
}
