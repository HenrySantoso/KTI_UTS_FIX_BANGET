using System;
using System.ComponentModel.DataAnnotations;

namespace SampleSecureWeb.Models;

public class Student
{
    [Key] //primary key
    public string Nim { get; set; } = null!;
    public string Name { get; set; } = null!;
}
