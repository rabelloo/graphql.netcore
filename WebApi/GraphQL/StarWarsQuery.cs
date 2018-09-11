using GraphQL.Types;
using System.Collections.Generic;
using System.Linq;

namespace StarWars.WebApi
{
    public class StarWarsQuery : GraphQLCombiner
    {
        public StarWarsQuery(DroidQuery droidQuery, FilmQuery filmQuery)
        {
            AddFields(droidQuery, filmQuery);
        }
    }
}
