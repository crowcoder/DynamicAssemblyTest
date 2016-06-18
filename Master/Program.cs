using System;
using System.IO;
using System.Reflection;

namespace Master
{
    class Program
    {
        static void Main(string[] args)
        {
            string assemPath = Assembly.GetExecutingAssembly().Location;
            int idx = assemPath.IndexOf("DynamicAssemblyTest");
            assemPath = Path.Combine(assemPath.Substring(idx), "ToLoad\\bin\\Debug\\ToLoad.exe");

            // Assembly loadedAssembly = Assembly.LoadFile(@"........\DynamicAssemblyTest\ToLoad\bin\Debug\ToLoad.exe");
            byte[] assemblyAsBytes = File.ReadAllBytes(@"C:\Users\tekhe\Documents\visual studio 2015\Projects\DynamicAssemblyTest\ToLoad\bin\Debug\ToLoad.exe");
            Assembly loadedAssembly = AppDomain.CurrentDomain.Load(assemblyAsBytes);
            MethodInfo mi = loadedAssembly.EntryPoint;

            System.Console.WriteLine("I am the Master");

            //var obj = loadedAssembly.CreateInstance(loadedAssembly.GetType().Name);
            var obj = loadedAssembly.CreateInstance(mi.Name);
            mi.Invoke(obj, null);

            Console.WriteLine("Its done, but I'm still running.");
            Console.ReadKey();

        }
    }
}
