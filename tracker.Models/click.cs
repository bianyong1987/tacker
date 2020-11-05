namespace tracker.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("click")]
    public partial class click
    {
        [Required]
        [StringLength(50)]
        public string clickid { get; set; }

        public int campaignId { get; set; }

        [StringLength(50)]
        public string siteDomain { get; set; }

        [StringLength(50)]
        public string ifa { get; set; }

        [StringLength(50)]
        public string ip { get; set; }

        [StringLength(50)]
        public string dspSsp { get; set; }

        public int isConvertsion { get; set; }

        public DateTime ts { get; set; }

        public int isDeleted { get; set; }

        public int offerId { get; set; }

        [StringLength(50)]
        public string siteId { get; set; }

        [StringLength(50)]
        public string appName { get; set; }

        public int? tp { get; set; }

        [StringLength(50)]
        public string remainID { get; set; }

        [StringLength(50)]
        public string conversionTS { get; set; }

        public int id { get; set; }

        [StringLength(50)]
        public string source { get; set; }

        public string ua { get; set; }

        public string lang { get; set; }
    }
}
