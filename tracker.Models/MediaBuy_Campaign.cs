namespace tracker.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MediaBuy_Campaign
    {
        public int id { get; set; }

        public int? mblId { get; set; }

        public int? campaignId { get; set; }

        public bool? isDeleted { get; set; }

        public int? weight { get; set; }
    }
}
