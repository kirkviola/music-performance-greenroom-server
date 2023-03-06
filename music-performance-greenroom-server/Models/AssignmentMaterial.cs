using System.Text.Json.Serialization;

namespace music_performance_greenroom_server.Models
{
    public class AssignmentMaterial
    {
        public int AssignmentMaterialId { get; set; }
        public string AssignmentMaterialName { get; set;} = string.Empty;
        public string AssignmentMaterialDescription { get; set; } = string.Empty;
        public byte[]? AssignmentMaterialAttachment { get; set; } = null;
        public int AssignmentId { get; set; }

        [JsonIgnore]
        public Assignment Assignment { get; set; }

        public AssignmentMaterial() {}
    }
}
