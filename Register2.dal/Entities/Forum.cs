namespace Register2.dal.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Forum")]
    public partial class Forum
    {
        public int ID { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime UpdateDate { get; set; }

        public int Deleted { get; set; }

        public bool Active { get; set; }

        public bool Default { get; set; }
    }
}
