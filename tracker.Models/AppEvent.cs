namespace tracker.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AppEvent")]
    public partial class AppEvent
    {
        public int id { get; set; }

        [StringLength(50)]
        public string clickid { get; set; }

        [StringLength(50)]
        public string eventID { get; set; }

        public bool? isDeleted { get; set; }

        [StringLength(50)]
        public string ts { get; set; }
    }
}
