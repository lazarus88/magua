using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using MovieDatabase_API.Db;
using MovieDatabase_API.Db.Entities;
using MovieDatabase_API.Models;

namespace MovieDatabase_API.Repository
{
    public interface IMovieDatabaseRepository
    {
        Task AddAsync(AddMovieRequest request);
        MovieEntity GetById(int id);
        MovieEntity Delete(DeleteMovieRequest request);
        Task<MovieEntity> UpdateAsync(UpdateMovieRequest request);
        Task SaveChangesAsync();
    }

    public class MovieDatabaseRepository : IMovieDatabaseRepository
    {
        private readonly MovieDbContext _db;

        public MovieDatabaseRepository(MovieDbContext db)
        {
            _db = db;
        }
        public async Task AddAsync(AddMovieRequest request)
        {
            var entity = new MovieEntity();
            entity.Name = request.Name;
            entity.Description = request.Description;
            entity.Director = request.Director;
            entity.Year = request.Year;
            entity.Datetime = DateTime.Now;
            entity.Status = StatusEnum.active;
            var check = _db.Movies
                 .Where(t => t.Year.Equals(request.Year))
                .Where(t => t.Name.Equals(request.Name))
                .Where(t => t.Description.Equals(request.Description))
                .Where(t => t.Director.Equals(request.Director))
                .FirstOrDefault();
            if (check != null)
            {
                if (check.Name != entity.Name || check.Description != entity.Description
                    || check.Director != entity.Director || check.Year != entity.Year)
                    await _db.Movies.AddAsync(entity);
            }
            else await _db.Movies.AddAsync(entity);
            return;
        }
        public MovieEntity GetById(int id)
        {
            var movie = _db.Movies.FirstOrDefault(m => m.id == id);
            return movie;
        }
        public  MovieEntity Delete( DeleteMovieRequest request)
        {
            var movie = _db.Movies.FirstOrDefault(m => m.id == request.id);
            if(movie.Status != request.status)
            {
                movie.Status = request.status;
                _db.Movies.Update(movie);
                return  movie;
            }
            return null;
        }
        public async Task<MovieEntity> UpdateAsync( UpdateMovieRequest request)
        {
            var movie = _db.Movies.FirstOrDefault(m => m.id == request.id);
            Console.WriteLine(movie.Name + "%%%%%%%%%%%%%%%%%%%%%" + request.Name);
            if (movie == null) return null;
            if (request.Description != null)
                movie.Description = request.Description;
            if (request.Name != null)
                movie.Name = request.Name;
            if (request.Year != null)
                movie.Year = request.Year;
            if (request.Director != null)
                movie.Director = request.Director;
            _db.Movies.Update(movie);
            return movie;
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
