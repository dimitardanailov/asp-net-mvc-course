using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeehiveStore.Models
{
    public class BaseModel
    {
        public BaseModel()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        [DataType(DataType.DateTime)]
        [Required]
        public DateTime CreatedAt { get; set; }

        [DataType(DataType.DateTime)]
        [Required]
        public DateTime UpdatedAt { get; set; }
    }
}