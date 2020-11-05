namespace tracker.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CampaignLog")]
    public partial class CampaignLog
    {
        public int id { get; set; }

        public int? campaignID { get; set; }

        public int? clickCount { get; set; }

        public int? impressionCount { get; set; }

        [StringLength(50)]
        public string TS { get; set; }

        public int? conversionCount { get; set; }
    }
}
