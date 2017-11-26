using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Lab20.Models
{
    public class Register
    {
        private string firstname;
        private string lastname;
        private string email;
        private string phonenumber;
        private string password;
        private string category;

        public Register() :this("","","","","")
        {
           
        }

        public Register(string firstname, string lastname, string email, string phonenumber, string password)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.email = email;
            this.phonenumber = phonenumber;
            this.password = password;   
        }

        [Required(ErrorMessage = "Name is Required!")]
        [RegularExpression("^[A-Za-z]{1,}$", ErrorMessage = "First name must be at least one letter.")]
        public string FirstName
        {
            set { firstname = value; }
            get { return firstname; }
        }

        [Required(ErrorMessage = "Name is Required!")]
        [RegularExpression("^[A-Za-z]{1,}$", ErrorMessage = "Last name must be at least one letter!")]
        public string LastName
        {
            set { lastname = value; }
            get { return lastname; }
        }


        [Required(ErrorMessage ="Email address is required!")]
        [EmailAddress(ErrorMessage ="Invalid email address.")]
        public string Email
        {

            set { email = value; }
            get { return email; }

        }


        [Required(ErrorMessage = "Phone number is required!")]
        [RegularExpression("^([0-9]{3}-[0-9]{3}-[0-9]{4})$",ErrorMessage = "Phone number must be in 123-456-7890 format.")]
        public string PhoneNumber
        {
            set { phonenumber = value; }
            get { return phonenumber; }
        }


        [Required(ErrorMessage = "Password is required!")]
        public string Password
        {
            set { password = value; }
            get { return password; }
        }

        public string Category
        {
            set { category = value; }
            get { return category; }

        }
    }
}