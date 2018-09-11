using System;

namespace StarWars.Core
{
    public class Film
    {
		public int Id { get; set; }
        public string Title { get; set; }
        public int? Episode { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
