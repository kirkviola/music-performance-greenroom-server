namespace music_performance_greenroom_server.Models
{
    public class UserCourse
    {
        public int UserCourseId { get; set; }
        public bool IsOwner { get; set; } = false;
        public int UserId { get; set; }
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
        public virtual User User { get; set; }

        public UserCourse() {}
    }
}
