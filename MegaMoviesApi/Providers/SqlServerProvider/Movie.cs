using System;
using System.Collections.Generic;

namespace MegaMoviesApi.Providers.SqlServerProvider
{
    public partial class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime ReleaseDate { get; set; }
    }
}
