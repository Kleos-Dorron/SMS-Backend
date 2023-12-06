using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SMS_Backend.Models;

public partial class AllocateClassroom
{
    [Key]
    public int AllocateClassroomId { get; set; }

    public int? TeacherId { get; set; }

    public int? ClassroomId { get; set; }

    public virtual Classroom? Classroom { get; set; }

    public virtual Teacher? Teacher { get; set; }
}
