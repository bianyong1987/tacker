namespace tracker.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("domain")]
    public partial class domain
    {
        public int id { get; set; }

        [Required]
        public string url { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string postbackUrl { get; set; }

        public int isDeleted { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [StringLength(50)]
        public string track { get; set; }
    }
}
