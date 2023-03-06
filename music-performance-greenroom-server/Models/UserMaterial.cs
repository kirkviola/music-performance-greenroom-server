using System.Text.Json.Serialization;

namespace music_performance_greenroom_server.Models
{
    public class UserMaterial
    {
        public int UserMaterialId { get; set; }
        public string UserMaterialName { get; set; } = string.Empty;
        public string UserMaterialDescription { get; set; } = string.Empty;
        public byte[]? UserMaterialAttachment { get; set; } 
        public int UserId { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }

        public UserMaterial() {}
    }
}
