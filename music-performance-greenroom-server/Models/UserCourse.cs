using Newtonsoft.Json;

namespace music_performance_greenroom_server.Models
{
    public class UserCourse
    {
        public int Id { get; set; }
        public bool IsOwner { get; set; } = false;
        public int UserId { get; set; }
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }

        public UserCourse() {}
    }
}
