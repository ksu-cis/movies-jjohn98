﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Movies
{
    /// <summary>
    /// A class representing a database of movies
    /// </summary>
    public static class MovieDatabase
    {
        private static List<Movie> movies;

        /// <summary>
        /// Loads the movie database from the JSON file
        /// </summary>

        public static List<Movie> Filter(List<string> rating)
        {
            List<Movie> result = new List<Movie>();

            foreach (Movie movie in All)
            {
                if (rating.Contains(movie.MPAA_Rating))
                {
                    result.Add(movie);
                }

            }
            return result;
        }

        public static List<Movie> SearchandFilter(string searchstring, List<string> rating)
        {
            List<Movie> result = new List<Movie>();

            foreach (Movie movie in All)
            {
                if (movie.Title.Contains(searchstring, StringComparison.CurrentCultureIgnoreCase) && rating.Contains(movie.MPAA_Rating))
                {
                    result.Add(movie);
                }
            }
            return result;
        }

        public static List<Movie> All
        {
            get
            {
                if (movies == null)
                {
                    using (StreamReader file = System.IO.File.OpenText("movies.json"))
                    {
                        string json = file.ReadToEnd();
                        movies = JsonConvert.DeserializeObject<List<Movie>>(json);
                    }
                }
                return movies;
            }
        }

        public static List<Movie> Search(List<Movie> movies, string searchstring)
        {
            List<Movie> result = new List<Movie>();

            foreach (Movie movie in movies)
            {
                if (movie.Title.Contains(searchstring, StringComparison.CurrentCultureIgnoreCase))
                {
                    result.Add(movie);
                }
            }

            return result;
        }

        public static List<Movie> FilterByMPAA(List<Movie> movies, List<string> mpaa)
        {
            List<Movie> results = new List<Movie>();

            foreach (Movie movie in movies)
            {
                if (mpaa.Contains(movie.MPAA_Rating))
                {
                    results.Add(movie);
                }
            }
            return results;
        }

        public static List<Movie> FilterByMinIMDB(List<Movie> movies, float minIMDB)
        {
            List<Movie> results = new List<Movie>();

            foreach (Movie movie in movies)
            {
                if (minIMDB >= movie.IMDB_Rating)
                {
                    results.Add(movie);
                }
            }
            return results;
        }

        public static List<Movie> FilterByMaxIMDB(List<Movie> movies, float maxIMDB)
        {
            List<Movie> results = new List<Movie>();

            foreach (Movie movie in movies)
            {
                if (maxIMDB <= movie.IMDB_Rating)
                {
                    results.Add(movie);
                }
            }
            return results;
        }
    }
}
