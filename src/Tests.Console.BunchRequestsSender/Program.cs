using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tests.Console.BunchRequestsSender.Device;

namespace Tests.Console.BunchRequestsSender
{
    internal class Program
    {
        private static readonly Uri _apiServiceUrl = new Uri(Common.ServiceFabric.Configuration.ApiServiceAddress);
        private static readonly int _threadsCount = 20;

        internal static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            Start();
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine(e.ExceptionObject);
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();

            Environment.Exit(1);
        }

        private static void Start()
        {
            var type = SelectDataType();
            switch (type)
            {
                case DataType.Devices:
                    ProcessDevices()
                        .GetAwaiter()
                        .GetResult();
                    return;
                case DataType.Locations:
                    ProcessLocations()
                        .GetAwaiter()
                        .GetResult();
                    return;
                default:
                case DataType.Exit: return;
            }
        }

        private static DataType SelectDataType()
        {
            System.Console.Clear();
            System.Console.WriteLine("Please select which data type need to be proceed:");

            var typeValues = Enum.GetValues(typeof(DataType))
                .Cast<DataType>()
                .ToList();

            typeValues
                .ForEach(x => System.Console.WriteLine($"{(int)x} - {x}"));

            var stringResult = System.Console.ReadLine();
            var intResult = 0;
            if (int.TryParse(stringResult, out intResult))
            {
                if (typeValues.Cast<int>().Contains(intResult))
                    return (DataType)intResult;
            }

            return SelectDataType();
        }

        private static async Task ProcessDevices()
        {
            System.Console.Clear();

            const int devicesCount = 100000;

            System.Console.WriteLine($"Adding {devicesCount} devices:");

            var tasks = new List<Task>();
            int count = 0;
            while (count < devicesCount)
            {
                var task = Publisher.PostDevice(_apiServiceUrl)
                    .ContinueWith(x =>
                    {
                        if (x.IsCompleted)
                            count++;
                    });
                tasks.Add(task);

                if (tasks.Count == _threadsCount || count == devicesCount)
                {
                    await Task.WhenAll(tasks);
                    tasks.Clear();

                    System.Console.WriteLine($"Added {count} devices.");
                }
            }

            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
            Start();
        }

        private static async Task ProcessLocations()
        {
            System.Console.Clear();

            var deviceIds = await Publisher.GetDevicesIds(_apiServiceUrl);

            System.Console.WriteLine($"Adding {deviceIds.Count()} locations:");

            var tasks = new List<Task>();
            int count = 0;
            foreach (var deviceId in deviceIds)
            {
                var task = Publisher.PostLocation(deviceId, _apiServiceUrl)
                    .ContinueWith(x =>
                    {
                        if (x.IsCompleted)
                            count++;
                    });
                tasks.Add(task);

                if (tasks.Count == _threadsCount || count == deviceIds.Count())
                {
                    await Task.WhenAll(tasks);
                    tasks.Clear();

                    System.Console.WriteLine($"Added {count} locations.");
                }
            }

            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
            Start();
        }

        private enum DataType
        {
            Exit,
            Devices,
            Locations
        }
    }
}