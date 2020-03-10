using System;
using JavaBridges.Api.PrimitiveTypes;
using JavonetBridge;

namespace DynamicJavonet.TestCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Javonet.Activate("support@javonet.com", "Qn8o-Lo5z-Rm2x-b7C2-Bn43", //use your real trial key
                @"C:\Program Files\Java\jdk1.8.0_192");
            Javonet.AddReference(@"..\..\..\jar\calc.jar");

            WithoutDJ();
            WithDJ();

            Console.ReadLine();
        }

        static void WithoutDJ()
        {
            var calc = Javonet.New("Calculator");
            var f1 = calc.Invoke<float>("Sub", new JPrimitive(1f / 3f), new JPrimitive(1f / 7f));
            var f2 = calc.Invoke<float>("Sub", 1f / 3f, 1f / 7f);
            var f3 = calc.Invoke<float>("TestFloat");
            
            var d1 = calc.Invoke<double>("DSub", new JPrimitive(1d / 3d), new JPrimitive(1d / 7d));
            var d2 = calc.Invoke<double>("DSub", 1d / 3d, 1d / 7d);
            var d3 = calc.Invoke<double>("TestDouble");

            Console.WriteLine($"Without DJ:\r\n{f1}\t{f2}\t{f3}\t{d1}\t{d2}\t{d3}");
        }

        static void WithDJ()
        {
            dynamic calc = DJ.New("Calculator");
            var f1 = calc.Sub(1f / 3f, 1f / 7f);
            var f2 = calc.Sub(new JPrimitive(1f / 3f), new JPrimitive(1f / 7f)); //In fact I'd like to use JObject
            var f3 = calc.TestFloat();

            var d1 = calc.DSub(1d / 3d, 1d / 7d);
            var d2 = calc.DSub(new JPrimitive(1d / 3d), new JPrimitive(1d / 7d));
            var d3 = calc.TestDouble();

            Console.WriteLine($"With DJ:\r\n{f1}\t{f2}\t{f3}\t{d1}\t{d2}\t{d3}");
        }
    }
}
