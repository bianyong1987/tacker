namespace tracker.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("uaDB")]
    public partial class uaDB
    {
        public int id { get; set; }

        public string ua { get; set; }

        public bool? isDeleted { get; set; }
    }
}
