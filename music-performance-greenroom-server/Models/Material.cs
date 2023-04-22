
using System.Text.Json.Serialization;

namespace music_performance_greenroom_server.Models
{
    public class Material
    {
        public int Id { get; set; }
        public string Title { get; set;} = string.Empty;
        public string Description { get; set; } = string.Empty;
        public byte[]? Attachment { get; set; } = null;
        public string? Url { get; set; } = null;
        public int? AssignmentId { get; set; }
        public int UserId { get; set; } // One user per material - material owner

        public virtual Assignment? Assignment { get; set; } = null;
        [JsonIgnore]
        public virtual User User { get; set; }

        public Material() 
        {
            this.Assignment = new Assignment();
            this.User = new User();
        }
    }
}
