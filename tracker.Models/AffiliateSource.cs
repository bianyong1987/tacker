namespace tracker.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AffiliateSource")]
    public partial class AffiliateSource
    {
        public int id { get; set; }

        public int? affiliateID { get; set; }

        [StringLength(50)]
        public string sourceValue { get; set; }

        public int? offerID { get; set; }

        [StringLength(50)]
        public string ts { get; set; }

        public bool? isDeleted { get; set; }

        [StringLength(50)]
        public string tag { get; set; }
    }
}
