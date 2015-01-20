using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeehiveStore.Models
{
    [Table("Products")]
    public class Product : BaseModel
    {
        [Key]
        public Int32 ProductID { get; set; }

        // Foreign Key
        [Required]
        public Int32 CategoryID { get; set; }

        // Foreign Key
        [Required]
        public Int32 StoreID { get; set; }

        [Required]
        public String Name { get; set; }

        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }

        [ForeignKey("StoreID")]
        public virtual Store Store { get; set; }
    }
}