﻿using cinema_be.Entities;
using cinema_be.Models.DTOs;

namespace cinema_be.Interfaces
{
    public interface IMovieService
    {
        List<Movie> GetMovies();

        Movie? GetMovieById(int id);
        void Create(CreateMovieDto movie);
        void Update(Movie movie);
        void Delete(int id);

    }
}
