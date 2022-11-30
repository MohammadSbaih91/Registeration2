namespace Register2.dal.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BasicSetting
    {
        public int ID { get; set; }

        public int TypeOfBasicSettings { get; set; }

        public bool BoolValue { get; set; }

        public int IntValue { get; set; }

        [StringLength(255)]
        public string Value { get; set; }

        public int Deleted { get; set; }

        public bool Active { get; set; }

        public bool Default { get; set; }
    }
}
