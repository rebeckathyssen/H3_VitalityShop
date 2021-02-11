using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

/* 
 The authenticate model defines the parameters for incoming POST requests to the /users/authenticate route of the api, 
it is set as the parameter to the Authenticate method of the UsersController. When an HTTP POST request is received to the route, 
the data from the body is bound to an instance of the AuthenticateModel, validated and passed to the method.

ASP.NET Core Data Annotations are used to automatically handle model validation, the [Required] attribute sets both 
the username and password as required fields so if either are missing a validation error message is returned from the api.
 */
namespace VitalityShop.Domain.Models
{
    public class AuthenticateModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
