using System;
using System.Collections.Generic;

namespace PRN221_GroupProject.Models
{
    public partial class Lesson
    {
        public int LessonId { get; set; }
        public int CourseId { get; set; }
        public string Content { get; set; } = null!;

        public virtual Course Course { get; set; } = null!;
    }
}
