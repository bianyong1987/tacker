namespace tracker.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("offerSource")]
    public partial class offerSource
    {
        public int id { get; set; }

        public string sourceVal { get; set; }

        public string itemVal { get; set; }

        public int? offerID { get; set; }

        public int? isDeleted { get; set; }
    }
}
