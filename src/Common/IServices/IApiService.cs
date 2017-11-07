using System.Threading.Tasks;

namespace Common.IServices
{
    public interface IApiService : IBaseService
    {
        Task SyncDevicesStatusesAsync();
    }
}