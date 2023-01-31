using MovieDatabase_API.Db.Entities;

namespace MovieDatabase_API.Models
{
    public class DeleteMovieRequest
    {
        public int id { get; set; }
        public StatusEnum status { get; set; }
    }
}
