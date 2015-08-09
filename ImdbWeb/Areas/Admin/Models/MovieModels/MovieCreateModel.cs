using MovieDAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        }

        [Display(Name = "ID")]
        [Required, RegularExpression("^[0-9]{5,15}$", ErrorMessage = "ID must consist of only numbers, and be between 8 and 14 digits.")]
        public string id { get { return movie.MovieId;  } set { movie.MovieId = value; } }

        [Display(Name = "Title")]
        [Required, RegularExpression("^.{1,100}$", ErrorMessage = "Title must be between 1 and 100 characters long")]
        public string title { get { return movie.Title; } set { movie.Title = value; } }

        [Display(Name = "Original Title")]
        [Required, RegularExpression("^.{1,100}$", ErrorMessage = "Title must be between 1 and 100 characters long")]
        public string orgTitle { get { return movie.OriginalTitle; } set { movie.OriginalTitle = value; } }

        [Display(Name = "Description")]
        public string desc { get { return movie.Description; } set { movie.Description = value; } }

        [Display(Name = "Genre")]
        public int genre
        {
            get
            {
                return (movie.Genre == null) ? -1 : movie.Genre.GenreId;
            }
            set
            {
                using (var db = new MovieDAL.ImdbContext())
                {
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

        [Display(Name = "Year produced")]
        [Required, Range(1800, 3000, ErrorMessage = "{0} is not a valid movie production year, pls be realistic.")]
        public string productionYear { get { return movie.ProductionYear; } set { movie.ProductionYear = value; } }

        [Display(Name = "Minutes (total)")]
        public int runLengthTotalMinutes { get { return movie.RunningLength; } set { movie.RunningLength = value; } }

        [Display(Name = "Hour(s)")]
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

        [Display(Name = "Minutes")]
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