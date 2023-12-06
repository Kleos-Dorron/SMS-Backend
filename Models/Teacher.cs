using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SMS_Backend.Models;

public partial class Teacher
{
    [Key]
    public int TeacherId { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string ContactNo { get; set; } = null!;

    public string EmailAddress { get; set; } = null!;

    public virtual ICollection<AllocateClassroom> AllocateClassrooms { get; set; } = new List<AllocateClassroom>();

    public virtual ICollection<AllocateSubject> AllocateSubjects { get; set; } = new List<AllocateSubject>();
}
