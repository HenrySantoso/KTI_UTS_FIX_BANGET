using System;
using System.ComponentModel.DataAnnotations;

namespace SampleSecureWeb.ViewModels;

public class RegistrationViewModel
{
    [Required]
    public string? Username{ get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string? Password{ get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Display (Name = "Confirm password")]
    [Compare("Password", ErrorMessage = "The password and confirmation passowrd do not match.")]
    public string? ConfirmPassword{ get; set; }
}
