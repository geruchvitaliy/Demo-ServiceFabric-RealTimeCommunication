using Api.Models;
using Common.Models.Device;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Tests.Console.BunchRequestsSender.Helpers;

namespace Tests.Console.BunchRequestsSender.Device
{
    internal static class Publisher
    {
        public static async Task<IEnumerable<DeviceId>> GetDevicesIds(Uri apiServiceUrl)
        {
            var url = new Uri(apiServiceUrl, $"api/device/ids?pageNumber=0&pageSize={int.MaxValue}");

            using (var client = GetHttpClient())
            {
                var response = await client.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                    throw new HttpRequestException("Cannot get devices ids");

                return await response.Content.ReadAsAsync<IEnumerable<DeviceId>>();
            }
        }

        public static async Task<Guid> PostDevice(Uri apiServiceUrl)
        {
            var model = new PostDevice { Name = Randomizer.String };
            var url = new Uri(apiServiceUrl, "api/device");

            using (var client = GetHttpClient())
            {
                var response = await client.PostAsJsonAsync(url, model);
                if (!response.IsSuccessStatusCode)
                    throw new HttpRequestException("Cannot post device");

                return await response.Content.ReadAsAsync<DeviceId>();
            }
        }

        public static async Task PostLocation(Guid deviceId, Uri apiServiceUrl)
        {
            var location = Randomizer.RandomKenyaLocation();
            var model = new PostLocation { Latitude = location.Item1, Longitude = location.Item2 };
            var url = new Uri(apiServiceUrl, $"api/device/{deviceId}/location");

            using (var client = GetHttpClient())
            {
                var response = await client.PostAsJsonAsync(url, model);
                if (!response.IsSuccessStatusCode)
                    throw new HttpRequestException("Cannot post location");
            }
        }

        private static HttpClient GetHttpClient() =>
            new HttpClient() { Timeout = TimeSpan.FromMinutes(10) };
    }
}