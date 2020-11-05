namespace tracker.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("campaign")]
    public partial class campaign
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Required]
        [StringLength(100)]
        public string url { get; set; }

        [StringLength(50)]
        public string redirect { get; set; }

        [StringLength(50)]
        public string brush { get; set; }

        [StringLength(50)]
        public string type { get; set; }

        public int? isUaLimits { get; set; }

        [StringLength(50)]
        public string tag { get; set; }

        public int isDeleted { get; set; }

        public int countryId { get; set; }

        public int trafficSourceId { get; set; }

        [Required]
        [StringLength(50)]
        public string conversion { get; set; }

        [Required]
        [StringLength(50)]
        public string domain { get; set; }

        [StringLength(50)]
        public string campaignPath { get; set; }

        public int? userId { get; set; }

        public bool? checkRepeatIP { get; set; }

        public bool? isImp { get; set; }

        public bool? clickRepeatIP { get; set; }
    }
}
