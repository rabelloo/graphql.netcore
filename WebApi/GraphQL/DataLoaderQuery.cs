using GraphQL.DataLoader;
using GraphQL.Types;
using System;
using System.Threading.Tasks;

namespace StarWars.WebApi
{
    public abstract class DataLoaderQuery : ObjectGraphType
    {
        private readonly IDataLoaderContextAccessor _accessor;

        public DataLoaderQuery(IDataLoaderContextAccessor accessor)
        {
            _accessor = accessor;
        }

        protected Task<T> Defer<T>(string loaderKey, Func<Task<T>> loader)
            => _accessor.Context
                .GetOrAddLoader(loaderKey, loader)
                .LoadAsync();
    }
}
