using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace General_Quarters.Models
{    
    public class User
    {
        [Key]
        public int UserId {get;set;}


        [Required(ErrorMessage="First name is required")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Only alphabetical characters are allowed")]
        [Display(Name = "First Name")]
        [MinLength(2, ErrorMessage="First name is too short")]
        public string FirstName {get;set;}


        [Required(ErrorMessage="Last name is required")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", 
            ErrorMessage = "Only alphabetical characters are allowed")]
        [Display(Name = "Last Name")]
        [MinLength(2, ErrorMessage="Last name is too short")]
        public string LastName {get;set;}


        [Required(ErrorMessage="An email address is required")]
        [EmailAddress]
        public string Email {get;set;}


        [Required(ErrorMessage="A password is required")]
        [MinLength(8, ErrorMessage="Must be 8 characters or longer")]
        [DataType(DataType.Password)]
        public string Password {get;set;}


        [NotMapped]
        [Required(ErrorMessage="Please confirm your password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage="Passwords do not match")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword {get;set;}


        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        // Navigation Prarameters
        public Profile Profile {get;set;}

        //np

        // ctor
        public string FullName()
        {
            return FirstName + " " + LastName;
        }
    }
}