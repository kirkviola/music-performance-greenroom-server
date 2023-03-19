using Newtonsoft.Json;

namespace music_performance_greenroom_server.Models
{
    public class UserPermission
    {
        public int Id { get; set; }
        public Permission Permission { get; set; }
        public int UserId { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }
        public UserPermission() { }
    }
}
