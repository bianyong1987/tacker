namespace tracker.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("campaignPath")]
    public partial class campaignPath
    {
        public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string val { get; set; }

        public int isDeleted { get; set; }
    }
}
