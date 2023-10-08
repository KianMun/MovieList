﻿using System.ComponentModel.DataAnnotations;

namespace MovieList.Models
{
	//Movie class with properties whose value is generated by the database
	public class Movie
	{
		[Key]
        public int MovieId { get; set; }
		[Required(ErrorMessage = "Please enter a name.")]
		public string Name{ get; set; }

		[Required(ErrorMessage = "Please enter a year.")]
		[Range(1889, 2999, ErrorMessage = "Year must be after 1889.")]
		public int? Year{ get; set; }
		
		[Required(ErrorMessage = "Please enter a rating.")]
		[Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
		public int? Rating{ get; set; }
    }
}