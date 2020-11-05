namespace tracker.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class offerDayStatistics
    {
        public int id { get; set; }

        public int offerId { get; set; }

        public int clicks { get; set; }

        public int conversions { get; set; }

        [Column(TypeName = "date")]
        public DateTime sDate { get; set; }

        public int isDeleted { get; set; }
    }
}
