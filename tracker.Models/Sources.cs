namespace tracker.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sources
    {
        public int id { get; set; }

        [StringLength(50)]
        public string source { get; set; }

        public bool? isDeleted { get; set; }

        [StringLength(50)]
        public string tag { get; set; }
    }
}
