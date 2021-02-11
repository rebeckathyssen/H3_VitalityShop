using System;
using System.Collections.Generic;
using System.Text;

/* This class holds the properties defined in the appsettings.json-file, which holds a Secret. 
 * This is used to access application options through objects, which will be injected into classes with DI.
 * As an example, UsersController.cs needs access to this file, which will happen through its IOptions <AppSettings>-method. */
namespace VitalityShop.Infrastructure.Repository.Helpers
{
    public class AppSettings
    {
        public string Secret { get; set; }
    }
}
