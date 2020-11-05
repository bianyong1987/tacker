namespace tracker.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MediaBuyLink")]
    public partial class MediaBuyLink
    {
        public int id { get; set; }

        public string launchLink { get; set; }

        [StringLength(50)]
        public string trafficName { get; set; }

        public bool? isDeleted { get; set; }

        [StringLength(50)]
        public string linkcode { get; set; }
    }
}
