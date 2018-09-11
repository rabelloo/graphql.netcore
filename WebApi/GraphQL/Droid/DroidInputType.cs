using GraphQL;
using GraphQL.Types;
using StarWars.Core;

namespace StarWars.WebApi
{
    public class DroidInputType : InputObjectGraphType<Droid>
    {
        public DroidInputType()
        {
            Name = "DroidInput";
            Field(x => x.Name).Description("The Droid's name");
        }
    }
}
