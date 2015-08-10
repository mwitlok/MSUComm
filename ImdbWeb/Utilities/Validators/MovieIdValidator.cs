using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImdbWeb.Utilities.Validators
{
	public class MovieIdValidator
	{
		public static ValidationResult checkExist(string movieId)
		{
			var db = new MovieDAL.ImdbContext();
			if(db.Movies.Find(movieId) == null)
			{
				return ValidationResult.Success;
			}

			return new ValidationResult("This movie already exists");
		}
	}
}