﻿using GraphQL;
using GraphQL.Types;

namespace StarWars.WebApi
{
    public class StarWarsSchema : Schema
    {
		public StarWarsSchema(IDependencyResolver resolver) : base(resolver)
        {
			Query = resolver.Resolve<StarWarsQuery>();
			Mutation = resolver.Resolve<StarWarsMutation>();
        }
    }
}
