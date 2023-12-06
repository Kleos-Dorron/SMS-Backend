using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SMS_Backend.Models;

public partial class Classroom
{
    [Key]
    public int ClassroomId { get; set; }

    public string ClassroomName { get; set; } = null!;

    public virtual ICollection<AllocateClassroom> AllocateClassrooms { get; set; } = new List<AllocateClassroom>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
