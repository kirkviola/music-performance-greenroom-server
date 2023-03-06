namespace music_performance_greenroom_server.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; } = string.Empty;
        public string CourseDescription { get; set; } = string.Empty;
        public int UserCourseId { get; set; }

        public virtual UserCourse[] UserCourses { get; set; }
        public virtual Assignment[] Assignments { get; set; }
        public Course() { }
    }
}
