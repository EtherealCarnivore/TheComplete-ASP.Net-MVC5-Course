using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VidlyProject.Models;

namespace VidlyProject.ViewModels
{
    public class MovieFormViewModel
    {
        

        public IEnumerable<Genre> Genres { get; set; }

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; } //set string not not null and lenght



        [Display(Name = "Genre")]
        [Required] //because the modal is binded with the ID, we need this field or we will get a null exception
        public byte? GenreId { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        
       
        [Display(Name = "Numbers in stock")]
        [Range(1, 20)]
        [Required]
        public byte? NumberInStock { get; set; }

        public string Title // I use this logic to handle the title of the Movie Form in the view
        {
            get
            {
                return Id != 0 ? " " : "New Movie"; 

            }
        }

        public MovieFormViewModel()
        {
            Id = 0; // to make sure that the HiddenFor field is populated
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }
    }
}