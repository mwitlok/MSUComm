using MovieDAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImdbWeb.Areas.Admin.Models.MovieModels
{
	public class MovieViewModel
	{
		[Required]
		[Display(Name = "ID")]
		[MinLength(8), MaxLength(15)]
		[CustomValidation(typeof(Utilities.Validators.MovieIdValidator), "checkExist")]
		[Remote("checkIdRemote", "Movie", HttpMethod = "POST")]
		public string id { get; set; }

		[Required]
		[Display(Name = "Title")]
		[MinLength(1), MaxLength(100)]
		public string title { get; set; }

		[Required]
		[Display(Name = "Original Title")]
		[MinLength(1), MaxLength(100)]
		public string origTitlte { get; set; }

		[Display(Name = "Description")]
		public string desc { get; set; }

		[Required]
		[Display(Name = "Min")]
		[Range(0,59)]
		public int runMin { get; set; }

		[Required]
        [Display(Name = "Hours")]
		[Range(0,10000000)]
		public int runHour { get; set; }

		[Required]
        [Display(Name = "Production Year")]
		[Range(1800, 3000)]
		public string prodYear { get; set; }

		[Required]
		[Display(Name = "Genre")]
		public int GenreId { get; set; }

		public IEnumerable<Genre> genreList
        {
            get
            {
                var db = new ImdbContext();
				return db.Genres.OrderBy(x => x.Name);
			}
        }
	}
}