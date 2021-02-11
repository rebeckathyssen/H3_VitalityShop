using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

/* 
 The register model defines the parameters for incoming POST requests to the /users/register route of the api, 
it is set as the parameter to the Register method of the UsersController. When an HTTP POST request is received to the route, 
the data from the body is bound to an instance of the RegisterModel, validated and passed to the method.

ASP.NET Core Data Annotations are used to automatically handle model validation, the [Required] attribute is used to mark all 
fields (first name, last name, username & password) as required so if any are missing a validation error message is returned from the api.
 */

namespace VitalityShop.Domain.Models
{
    public class RegisterModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public int Phone { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public int Housenumber { get; set; }

        [Required]
        public int Zipcode { get; set; }
    }
}
