using HwMonCore.Hardware;
using System;
using System.Linq;
using System.Text;
using System.Threading;

namespace HwMonCoreConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var settings = new InMemorySettings();

            var computer = new Computer(settings);
            computer.Open();

            computer.CPUEnabled = true;

            while (true)
            {
                var report = GetReport(computer);
                Console.Clear();
                Console.Write(report);

                Thread.Sleep(500);
            }
        }

        private static string GetReport(Computer comp)
        {
            var s = new StringBuilder();

            s.AppendLine(comp.Hardware[0].Name);
            foreach(var sensor in comp.Hardware[0].Sensors)
            {
                s.AppendLine($"{sensor.Name} - {sensor.SensorType}: {sensor.Value}");
            }

            return s.ToString();
        }
    }
}
