using GraphQL;
using GraphQL.DataLoader;
using GraphQL.Types;
using StarWars.Core;

namespace StarWars.WebApi
{
    public class DroidMutation : ObjectGraphType
    {
		public DroidMutation(IDataLoaderContextAccessor accessor, IDroidRepository droids)
        {
			Field<IntGraphType>(
                "addDroid",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<DroidInputType>> { Name = "droid" }
                ),
                resolve: context =>
                    droids.Add(context.GetArgument<Droid>("droid"))
                );
        }
    }
}
