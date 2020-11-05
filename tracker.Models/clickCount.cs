namespace tracker.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("clickCount")]
    public partial class clickCount
    {
        public int id { get; set; }

        public int? offerID { get; set; }

        public int? clickSum { get; set; }

        [StringLength(50)]
        public string TS { get; set; }

        public bool? isDeleted { get; set; }
    }
}
