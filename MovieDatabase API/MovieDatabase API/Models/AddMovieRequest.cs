using MovieDatabase_API.Db.Entities;

namespace MovieDatabase_API.Models
{
    public class AddMovieRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
    }
}
