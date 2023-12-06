using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SMS_Backend.Models;

public partial class AllocateSubject
{
    [Key]
    public int AllocateSubjectId { get; set; }

    public int? TeacherId { get; set; }

    public int? SubjectId { get; set; }

    public virtual Subject? Subject { get; set; }

    public virtual Teacher? Teacher { get; set; }
}
