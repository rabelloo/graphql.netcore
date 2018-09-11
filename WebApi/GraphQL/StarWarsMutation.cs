using GraphQL.Types;
using System.Collections.Generic;
using System.Linq;

namespace StarWars.WebApi
{
    public class StarWarsMutation : GraphQLCombiner
    {
		public StarWarsMutation(DroidMutation droidMutation)
        {
            AddFields(droidMutation);
        }
    }
}
