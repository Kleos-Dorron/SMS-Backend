using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SMS_Backend.Models;

public partial class Student
{
    [Key]
    public int StudentId { get; set; }

    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string ContactPerson { get; set; } = null!;
    public string ContactNo { get; set; } = null!;
    public string EmailAddress { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public int Age { get; set; }

    public int ClassroomId { get; set; }


    public virtual Classroom? Classroom { get; set; }
}
