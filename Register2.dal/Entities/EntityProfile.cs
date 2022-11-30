namespace Register2.dal.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EntityProfile")]
    public partial class EntityProfile
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EntityProfile()
        {
            EntityProfileItems = new HashSet<EntityProfileItem>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Entity { get; set; }

        public string OriginalType { get; set; }

        public int Deleted { get; set; }

        public bool Active { get; set; }

        public bool Default { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EntityProfileItem> EntityProfileItems { get; set; }
    }
}
