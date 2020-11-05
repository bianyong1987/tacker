namespace tracker.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class campaign_offer
    {
        public int id { get; set; }

        public int campaignId { get; set; }

        public int offerId { get; set; }

        public double? weight { get; set; }

        public int isDeleted { get; set; }
    }
}
