using System;
using System.ComponentModel.DataAnnotations;

namespace General_Quarters.Models
{
    public class Profile
    {
        [Key]
        public int ProfileId {get;set;}
        
        [Required]
        [MinLength(2)]
        [Display(Name = "User Name")]
        public string UserName {get;set;}

        [Required]
        public string Location {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        // Foreign Keys
        public int UserId {get;set;}

        // Navigation Parameteres
        public User User {get;set;}
    }
}