namespace tracker.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("source")]
    public partial class source
    {
        public int id { get; set; }

        [StringLength(50)]
        public string val { get; set; }

        public int? isDeleted { get; set; }

        public int? userID { get; set; }
    }
}
