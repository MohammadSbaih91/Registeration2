namespace Register2.dal.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EntityProfileItem")]
    public partial class EntityProfileItem
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Group { get; set; }

        public bool Visible { get; set; }

        public bool VisibleInTheGrid { get; set; }

        public bool Required { get; set; }

        public bool Advanced { get; set; }

        public bool Searchable { get; set; }

        public int Deleted { get; set; }

        public bool Active { get; set; }

        public bool Default { get; set; }

        public int? EntityProfile_ID { get; set; }

        public virtual EntityProfile EntityProfile { get; set; }
    }
}
