using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SMS_Backend.Models;

public partial class Subject
{
    [Key]
    public int SubjectId { get; set; }

    public string SubjectName { get; set; } = null!;

    public virtual ICollection<AllocateSubject> AllocateSubjects { get; set; } = new List<AllocateSubject>();
}
