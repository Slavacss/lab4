namespace lab1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("contract")]
    public partial class contract
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public contract()
        {
            obje = new HashSet<obje>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int contractID { get; set; }

        [Required]
        [StringLength(50)]
        public string contract_name { get; set; }

        [Required]
        [StringLength(50)]
        public string contract_type { get; set; }

        [Required]
        [StringLength(50)]
        public string price { get; set; }

        [Column(TypeName = "date")]
        public DateTime date { get; set; }

        public int clientFK { get; set; }

        public int workerFK { get; set; }

        public virtual client client { get; set; }

        public virtual worker worker { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<obje> obje { get; set; }
    }
}
