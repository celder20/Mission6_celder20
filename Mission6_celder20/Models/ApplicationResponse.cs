using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6_celder20.Models
{
    //All the forms and if they are required or not. If a form that is required is not input,
    //it shoots them a message
    public class ApplicationResponse
    {
        [Key]
        [Required]
        public int AppId { get; set; }
        
        [Required(ErrorMessage = "You have to enter a movie title!")]
        public string Title { get; set; }

        //There were no movies before the 1850s
        [Required]
        [Range(1850, 2023, ErrorMessage = "Please enter a year between 1850 and 2023.")]
        public int Year { get; set; }
        [Required(ErrorMessage = "Please enter a director name.")]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }

        public bool Edited { get; set; }
        public string LentTo { get; set; }
        [MaxLength(25)]
        public string Notes { get; set; }

        //Build foreign key relationship
        [Required]
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
