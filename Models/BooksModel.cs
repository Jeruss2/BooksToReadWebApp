using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BooksToReadWebApp.Models
{
    public class BooksModel
    {
        public int id { get; set; }
        [Required]
        [DisplayName ("Title")]
        public string title { get; set; }
        [Required]
        [DisplayName("Authors")]
        public string authors { get; set; }

        public BooksModel()
        {
            id = -1;
            title = "Nothing";
            authors = "Nothing";
        }


        public BooksModel(int id, string title, string authors)
        {
            this.id = id; 
            this.title = title; 
            this.authors = authors;
        }
    }

}