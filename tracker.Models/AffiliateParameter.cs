namespace tracker.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AffiliateParameter")]
    public partial class AffiliateParameter
    {
        public int id { get; set; }

        [StringLength(50)]
        public string parameter { get; set; }

        [StringLength(50)]
        public string subparameter1 { get; set; }

        [StringLength(50)]
        public string subparameter2 { get; set; }

        [StringLength(50)]
        public string subparameter3 { get; set; }

        [StringLength(200)]
        public string tag { get; set; }

        public bool? isDeleted { get; set; }
    }
}
