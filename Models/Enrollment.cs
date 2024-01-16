using System;
using System.Collections.Generic;

namespace ServiceBasedApplication.Models;

public class Enrollment
{
    public int Id { get; set; }
    
    public int? Grade { get; set; }
    
    public int CourseId { get; set; }

    public int StudentId { get; set; }

    public virtual Course Course { get; set; } = null!;
    
    public virtual Student Student { get; set; } = null!;
}
