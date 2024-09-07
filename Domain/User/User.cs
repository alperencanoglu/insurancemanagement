using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Domain.User;

public class User:IdentityUser
{
   
    public string Name { get; set; }
    public Int16 ProfileType { get; set; }
}