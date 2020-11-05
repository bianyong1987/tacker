namespace tracker.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("user")]
    public partial class user
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Required]
        [StringLength(50)]
        public string password { get; set; }

        public string ticket { get; set; }

        public DateTime? stime { get; set; }

        [Required]
        [StringLength(50)]
        public string role { get; set; }

        public int isDeleted { get; set; }

        [StringLength(50)]
        public string workGroup { get; set; }
    }
}
