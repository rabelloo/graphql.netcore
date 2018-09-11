using GraphQL;
using GraphQL.DataLoader;
using GraphQL.Types;
using StarWars.Core;

namespace StarWars.WebApi
{
    public class DroidQuery : DataLoaderQuery
    {
		public DroidQuery(IDataLoaderContextAccessor accessor, IDroidRepository droids) : base(accessor)
        {
			Field<DroidType>(
                "droid",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "id" },
                    new QueryArgument<StringGraphType> { Name = "name" }
                ),
                resolve: context => {
                    var id = context.GetArgument<int>("id");
                    var name = context.GetArgument<string>("name");

                    return Defer("GetDroid", () =>
                        id > 0
                            ? droids.Get(id)
                            : droids.Get(name)
                    );
                });
                
			Field<ListGraphType<DroidType>>(
                "droids",
                resolve: context =>
                    Defer("GetDroids", () => droids.Get())
                );
        }
    }
}
