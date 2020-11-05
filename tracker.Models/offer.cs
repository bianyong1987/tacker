namespace tracker.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("offer")]
    public partial class offer
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Required]
        public string url { get; set; }

        public decimal payout { get; set; }

        public int countryid { get; set; }

        public int affiliateid { get; set; }

        public int max_visits_perday { get; set; }

        public int interval_sec_between_visit { get; set; }

        [StringLength(50)]
        public string tag { get; set; }

        public int isDeleted { get; set; }

        public int? userId { get; set; }

        [StringLength(50)]
        public string source { get; set; }

        public string scope { get; set; }

        public int? businessID { get; set; }

        public string impUrl { get; set; }

        public int? sourcesId { get; set; }
    }
}
