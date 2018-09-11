using GraphQL;
using GraphQL.Types;
using StarWars.Core;

namespace StarWars.WebApi
{
    public class FilmType : ObjectGraphType<Film>
    {
        public FilmType()
        {
            Name = "Film";
            Field(x => x.Id).Description("The Id of the Film");
            Field(x => x.Title).Description("The Film's title");
            Field(x => x.Episode, nullable: true).Description("The Film's episode number");
            Field(x => x.ReleaseDate).Description("The date in which the Film was released");
        }
    }
}
