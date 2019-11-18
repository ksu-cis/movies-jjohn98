using System;
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
    public class MovieDatabase
    {
        private List<Movie> movies = new List<Movie>();

        /// <summary>
        /// Loads the movie database from the JSON file
        /// </summary>
        public MovieDatabase() {
            
            using (StreamReader file = System.IO.File.OpenText("movies.json"))
            {
                string json = file.ReadToEnd();
                movies = JsonConvert.DeserializeObject<List<Movie>>(json);
            }
        }

        public List<Movie> Filter(List<string> rating)
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

        public List<Movie> SearchandFilter(string searchstring, List<string> rating)
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

        public List<Movie> All { get { return movies; } }

        public List<Movie> Search(string searchstring)
        {
            if (searchstring == null)
            {
                return All;
            }
            List<Movie> result = new List<Movie>();

            foreach (Movie movie in All)
            {
                if (movie.Title.Contains(searchstring, StringComparison.CurrentCultureIgnoreCase))
                {
                    result.Add(movie);
                }
            }

            return result;
        }
    }
}
