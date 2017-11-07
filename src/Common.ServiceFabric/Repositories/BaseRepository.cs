using Common.IRepositories;
using Common.ServiceFabric.Actors;

namespace Common.ServiceFabric.Repositories
{
    public abstract class BaseRepository : IBaseRepository
    {
        protected readonly IActorProvider _actorProvider;

        public BaseRepository(IActorProvider actorProvider)
        {
            _actorProvider = actorProvider;
        }
    }
}