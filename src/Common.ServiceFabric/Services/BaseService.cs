using Common.IServices;
using System;
using System.Net.Http;

namespace Common.ServiceFabric.Services
{
    public abstract class BaseService : IBaseService
    {
        protected static readonly Uri _baseApiUrl = new Uri(Configuration.ApiServiceAddress);

        protected HttpClient GetHttpClient() =>
            new HttpClient() { Timeout = TimeSpan.FromMinutes(10) };
    }
}