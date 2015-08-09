using MovieDAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ImdbWeb.Areas.Admin.Models.MovieModels
{
    public class MovieCreateModel
    {
        private readonly int minutesInAnHour = 60;
        public Movie movie { get; set; }

        public MovieCreateModel()
        {
            movie = new Movie();
            //movie.Description = "";
            //movie.MovieId = "";
            //movie.Title = "";
            //movie.OriginalTitle = "";
            //movie.ProductionYear = "";
            //movie.RunningLength = 0;
        }

        [DisplayName("ID")]
        public string id { get { return movie.MovieId;  } set { movie.MovieId = value; } }

        [DisplayName("Title")]
        public string title { get { return movie.Title; } set { movie.Title = value; } }

        [DisplayName("Original Title")]
        public string orgTitle { get { return movie.OriginalTitle; } set { movie.OriginalTitle = value; } }

        [DisplayName("Description")]
        public string desc { get { return movie.Description; } set { movie.Description = value; } }

        [DisplayName("Genre")]
        public int genre
        {
            get
            {
                return (movie.Genre == null) ? 0 : movie.Genre.GenreId;
            }
            set
            {
                using (var db = new MovieDAL.ImdbContext())
                {
                    //movie.Genre = db.Genres.Where(x => x.Name.Equals(value, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                    movie.Genre = db.Genres.Find(value);
                }
            }
        }

        public IEnumerable<Genre> genres
        {
            get
            {
                using (var db = new MovieDAL.ImdbContext())
                {
                    return db.Genres.OrderBy(x => x.Name).ToList();
                }
            }
        }

        [DisplayName("Year produced")]
        public string productionYear { get { return movie.ProductionYear; } set { movie.ProductionYear = value; } }

        [DisplayName("Minutes (total)")]
        public int runLengthTotalMinutes { get { return movie.RunningLength; } set { movie.RunningLength = value; } }

        [DisplayName("Hour(s)")]
        public int runLengthHours
        {
            get
            {
                return movie.RunningLength / minutesInAnHour;
            }
            set
            {
                movie.RunningLength = runLengthMinutes + (value * minutesInAnHour);
            }
        }

        [DisplayName("Minutes")]
        public int runLengthMinutes
        {
            get
            {
                return movie.RunningLength % minutesInAnHour;
            }
            set
            {
                movie.RunningLength = (runLengthHours * minutesInAnHour) + value;
            }
        }


    }
}