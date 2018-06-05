using System;

namespace MediaCatalog.Models
{
    public class Media
    {
		public int ID { get; set; }
		public string Title { get; set; }
		public string MediaType { get; set; }
		public string Format { get; set; }
		public int Duration { get; set; }
		public string Genre { get; set; }
		public int Year { get; set; }
		public int Rating { get; set; }
		public string Location { get; set; }
		public string Notes { get; set; }
    }
}
