using System;
using System.ComponentModel.DataAnnotations;

namespace SampleSecureWeb.ViewModels;

public class ChangePasswordViewModel
{
    //2.1.6 – Require Current and New Password for Change
    [Required]
    public string Username { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Password)]
    public string OldPassword { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Password)]
    [MinLength(12, ErrorMessage = "Password must be at least 12 characters long")]
    [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).+$",
        ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, and one number.")]
    public string NewPassword { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Password)]
    [Compare("NewPassword", ErrorMessage = "New Password and Confirmation do not match")]
    public string ConfirmNewPassword { get; set; } = string.Empty;
}