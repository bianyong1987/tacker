namespace tracker.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LWCallback")]
    public partial class LWCallback
    {
        public int id { get; set; }

        [StringLength(50)]
        public string idfa { get; set; }

        public DateTime? TS { get; set; }

        public int isDeleted { get; set; }
    }
}
