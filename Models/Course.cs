using System;
using System.Collections.Generic;

namespace ServiceBasedApplication.Models;

public class Course
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public int Credits { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
