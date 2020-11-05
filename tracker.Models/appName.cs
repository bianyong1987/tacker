namespace tracker.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("appName")]
    public partial class appName
    {
        public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string val { get; set; }

        public int isDeleted { get; set; }

        public int countryId { get; set; }

        public int? userId { get; set; }

        public string pkg_name { get; set; }

        [StringLength(50)]
        public string pkg_id { get; set; }

        public int? sourceID { get; set; }
    }
}
