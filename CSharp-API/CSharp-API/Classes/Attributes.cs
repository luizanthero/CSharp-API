using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_API.Classes
{
    class Attributes
    {
        public Titles titles { get; set; }
        public Poster posterImage { get; set; }
        public string canonicalTitle { get; set; }
        public string synopsis { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string ageRatingGuide { get; set; }
        public string youtubeVideoId { get; set; }
        public string episodeCount { get; set; }
        public string episodeLength { get; set; }
    }
}
