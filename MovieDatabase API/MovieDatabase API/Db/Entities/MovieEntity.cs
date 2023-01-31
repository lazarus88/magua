namespace MovieDatabase_API.Db.Entities
{
    public enum StatusEnum
    {
        active,
        inactive
    }
    public class MovieEntity
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public StatusEnum Status { get; set; }
        public DateTime Datetime { get; set; }
    }
}
