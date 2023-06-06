using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MvcMovieDemo.Models
{
    public class Movie
    {
        public int MovieID { get; set; }
        [Required] 
        public string Title { get; set; }
        [Display(Name = "Release date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true,
          DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public string Genre { get; set; }
        public int? Price { get; set; }
        public int RatingID { get; set; }

        public Rating Rating { get; set; }

    }
}
