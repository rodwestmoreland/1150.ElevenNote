﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Data
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        
        [Required]
        public Guid OwnerId { get; set; }
        
        public string Title { get; set; } //category title
        public string Description { get; set; } = "";

        
    }
}
