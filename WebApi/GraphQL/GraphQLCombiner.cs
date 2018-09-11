using GraphQL.Types;
using System.Collections.Generic;
using System.Linq;

namespace StarWars.WebApi
{
    public abstract class GraphQLCombiner : ObjectGraphType
    {
        protected void AddFields<T>(params ComplexGraphType<T>[] queries)
        {
            foreach (var field in queries.SelectMany(q => q.Fields))
                AddField(field);
        }
    }
}
