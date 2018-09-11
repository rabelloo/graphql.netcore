using GraphQL;
using GraphQL.Types;
using StarWars.Core;

namespace StarWars.WebApi
{
    public class DroidType : ObjectGraphType<Droid>
    {
        public DroidType()
        {
            Name = "Droid";
            Field(x => x.Id).Description("The Id of the Droid");
            Field(x => x.Name).Description("The Droid's name");
        }
    }
}
