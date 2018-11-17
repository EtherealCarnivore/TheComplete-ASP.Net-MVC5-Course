using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VidlyProject.Models;

namespace VidlyProject.Dtos
{
    public class MovieDto { 
    
    public int Id { get; set; }

    
    public string Name { get; set; } 

    public byte GenreId { get; set; }

    public GenreDto Genre { get; set; }

    public DateTime DateAdded { get; set; }


    public DateTime ReleaseDate { get; set; }

    public byte NumberInStock { get; set; }

    }
}