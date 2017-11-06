using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItunesSearch.Bll.Models
{
    [Table("SearchResultCounter")]
    public class SearchResultDTO
    {
        [Key]

        public long Id { get; set; }

        public string TrackId { get; set; }

        public string TrackName { get; set; }

        public string ArtistName { get; set; }

        public string Category { get; set; }

        public long ClickCount { get; set; }

        public string UserIP { get; set; }

        public string UserAgent { get; set; }

        public DateTime RowCreateTS { get; set; }

        public DateTime RowMaintainedTS { get; set; }

       
    }
}
