namespace tracker.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("loginHistory")]
    public partial class loginHistory
    {
        public int id { get; set; }

        public int userId { get; set; }

        public DateTime ts { get; set; }

        public int isDeleted { get; set; }
    }
}
