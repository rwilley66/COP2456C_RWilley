using System;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Linq;
using System.Collections.Generic;

namespace MediaCatalog.Models
{
    public class Media
    {
		public int ID { get; set; }

		[Required]
		public string Title { get; set; }

		[Display(Name = "Media Type")]
		[Required]
		public string MediaType { get; set; }

		public string Format { get; set; }

		[RegularExpression(@"^(\s*|\d+)$")]
		public int Duration { get; set; }

		public string Genre { get; set; }

		[RegularExpression(@"^(\s*|\d{4})$")]
		public int Year { get; set; }

		[Range(1, 5)]
        public int Rating { get; set; }

		public string Location { get; set; }

		public string Notes { get; set; }
    }

    
}
