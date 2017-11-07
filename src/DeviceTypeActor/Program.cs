using Microsoft.ServiceFabric.Actors.Runtime;
using System;
using System.Threading;

namespace DeviceTypeActor
{
    internal static class Program
    {
        private static void Main()
        {
            try
            {
                ActorRuntime.RegisterActorAsync<DeviceTypeActor>(
                   (context, actorType) => new ActorService(context, actorType)).GetAwaiter().GetResult();

                Thread.Sleep(Timeout.Infinite);
            }
            catch (Exception e)
            {
                ActorEventSource.Current.ActorHostInitializationFailed(e.ToString());
                throw;
            }
        }
    }
}