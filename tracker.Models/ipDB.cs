namespace tracker.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ipDB")]
    public partial class ipDB
    {
        public int id { get; set; }

        public string ip { get; set; }

        [StringLength(50)]
        public string country { get; set; }

        public bool? isDeleted { get; set; }
    }
}
