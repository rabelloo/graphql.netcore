using GraphQL.DataLoader;
using GraphQL.Types;
using StarWars.Core;

namespace StarWars.WebApi
{
    public class FilmQuery : DataLoaderQuery
    {
        public FilmQuery(IDataLoaderContextAccessor accessor, IFilmRepository films) : base(accessor)
        {
            Field<FilmType>(
                "film",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "id" },
                    new QueryArgument<IntGraphType> { Name = "episode" },
                    new QueryArgument<StringGraphType> { Name = "title" }
                ),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    var episode = context.GetArgument<int>("episode");
                    var title = context.GetArgument<string>("title");

                    return Defer("GetFilm", () =>
                        id > 0
                            ? films.Get(id)
                        : episode > 0
                            ? films.GetByEpisode(episode)
                            : films.Get(title)
                    );
                }
            );

            Field<ListGraphType<FilmType>>(
                "films",
                resolve: context => Defer("GetFilms", () =>
                    films.Get()
                )
            );
        }
    }
}
