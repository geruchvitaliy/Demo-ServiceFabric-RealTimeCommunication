using Common.IServices;
using System;
using System.Threading.Tasks;

namespace Common.ServiceFabric.Services
{
    public sealed class ApiService : BaseService, IApiService
    {
        public async Task SyncDevicesStatusesAsync()
        {
            var url = new Uri(_baseApiUrl, $"api/device/sync");

            using (var client = GetHttpClient())
                await client.PutAsync(url, null);
        }
    }
}