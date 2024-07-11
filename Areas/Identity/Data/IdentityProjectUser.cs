using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace IdentityProject.Areas.Identity.Data;

// Add profile data for application users by adding properties to the IdentityProjectUser class
public class IdentityProjectUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

