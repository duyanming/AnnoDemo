using System;


namespace registryCenter
{
    using Anno.Rpc.Center;
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "AnnoTrace Registry Center";
            Bootstrap.StartUp(args);
        }
    }
}
