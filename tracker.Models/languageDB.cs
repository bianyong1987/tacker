namespace tracker.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("languageDB")]
    public partial class languageDB
    {
        public int id { get; set; }

        public string language { get; set; }

        [StringLength(50)]
        public string country { get; set; }

        public bool? isDeleted { get; set; }
    }
}
