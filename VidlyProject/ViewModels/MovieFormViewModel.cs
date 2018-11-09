using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyProject.Models;

namespace VidlyProject.ViewModels
{
    public class MovieFormViewModel
    {
        
        public Movie Movie { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        public string Title // I use this logic to handle the title of the Movie Form in the view
        {
            get
            {
                if (Movie != null && Movie.Id != 0)
                {
                    return "Edit Movie";
                }
                else
                {
                    return "New Movie";
                }
            }
        }
    }
}