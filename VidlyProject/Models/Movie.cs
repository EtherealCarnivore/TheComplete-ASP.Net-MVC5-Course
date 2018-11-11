using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace VidlyProject.Models
{
    public class Movie
    {
       
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; } //set string not not null and lenght

        
        public Genre Genre { get; set; }

        [Display(Name = "Genre")]
        [Required] //because the modal is binded with the ID, we need this field or we will get a null exception
        public byte GenreId { get; set; }

        public DateTime DateAdded { get; set; }

        
        [Display(Name = "Release Date")]
        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Range(1,20)]
        [Display(Name = "Numbers in stock")]
        public byte NumberInStock { get; set; }

    }
}