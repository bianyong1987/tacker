namespace tracker.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SourcesItem")]
    public partial class SourcesItem
    {
        public int id { get; set; }

        [StringLength(50)]
        public string item { get; set; }

        public int? sourceID { get; set; }

        public bool? isDeleted { get; set; }
    }
}
