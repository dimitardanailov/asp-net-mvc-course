using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace BeehiveStore.Models
{
    [Table("Stories")] 
    public partial class Store:BaseModel
    {
        public Store()
        {
            this.Categories = new List<Category>();
        }

        [Key]
        public Int32 StoreID { get; set; }

        [Required]
        public String Brand { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }

        [Required]
        public String Phone { get; set; }

        [MinLength(20)]
        public String Description { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}
