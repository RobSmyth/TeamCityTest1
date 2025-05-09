namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var delayMilliseconds = int.Parse(args[0]);

            Console.WriteLine("Hello, World!");
            Thread.Sleep(1);
            Console.WriteLine("My test app");

            Thread.Sleep(delayMilliseconds);
        }
    }
}
