namespace tracker.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("offerReportList")]
    public partial class offerReportList
    {
        public int id { get; set; }

        public int? offerId { get; set; }

        public string name { get; set; }

        public int? clicks { get; set; }

        public int? conversions { get; set; }

        public double? revenue { get; set; }

        public int? userID { get; set; }

        public int? businessID { get; set; }

        [StringLength(50)]
        public string recordDate { get; set; }

        public bool? isDeleted { get; set; }
    }
}
