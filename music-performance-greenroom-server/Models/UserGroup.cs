using Newtonsoft.Json;

namespace music_performance_greenroom_server.Models
{
    public class UserGroup
    {
        public int Id { get; set; }
        public bool IsOwner { get; set; } = false;
        public int UserId { get; set; }
        public int GroupId { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }
        [JsonIgnore]
        public virtual Group Group { get; set; }
        public UserGroup() { }
    }
}
