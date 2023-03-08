using System;

namespace EngineTester
{
    internal class Program
    {
        const double I = 10;
        readonly static double[] M = { 20, 75, 100, 105, 75, 0 };
        readonly static double[] V = { 0, 75, 150, 200, 250, 300 };
        const double T_OVERHEAT = 110;
        const double H_M = 0.01;
        const double H_V = 0.0001;
        const double C = 0.1;
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the environment temperature: ");
            double tEnv = double.Parse(Console.ReadLine().Replace(".", ","));
            Engine engine = new InternalCombustionEngine(I, M, V, T_OVERHEAT, H_M, H_V, C, tEnv);
            var ts = new TestStand(engine);
            Console.WriteLine(ts.TestForOverheating(5).ToString());
        }
    }
}
