using System;
using System.Threading.Tasks;

namespace ToLoad
{
    public class Servant
    {
        public static void Main()
        {
            DelayMe().Wait();
        }

        private async static Task DelayMe()
        {
            await Task.Delay(3000);
            Console.WriteLine("Hello from the loaded assembly.");
        }
    }
}
