using BeehiveStore.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeehiveStore.Models
{
    [Table("Categories")] 
    public class Category:BaseModel
    {
        [Key]
        public Int32 CategoryID { get; set; }

        // Foreign Key
        public Int32? StoreID { get; set; }

        // Self Join
        public Int32? ParentID { get; set; }

        [Required]
        public String Name { get; set; }

        [MinLength(15), MaxLength(60, ErrorMessage = "SeoName must be 60 characters or less")]
        [StringLength(60)] 
        public String SeoName { get; set; }

        [MinLength(20)]
        [Column("Description", TypeName = "ntext")] // 65536
        public String Description { get; set; }

        [MinLength(20), MaxLength(180)]
        [StringLength(180)] 
        public String SeoDescription { get; set; }

        public Boolean? IsApproved { get; set; }

        [Required]
        public CategoryTypes Type { get; set; }

        [ForeignKey("StoreID")] 
        public virtual Store Store { get; set; }

        [ForeignKey("ParentID")] 
        public virtual Category ParentCategory { get; set; }
    }
}