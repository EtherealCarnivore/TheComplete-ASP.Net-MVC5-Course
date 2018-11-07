﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyProject.Models
{
    public class Genre
    {
        public byte Id { get; set; }

        //force non nullable and lenght
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}