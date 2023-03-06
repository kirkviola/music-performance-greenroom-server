using System.Text.Json.Serialization;

namespace music_performance_greenroom_server.Models
{
    public class Assignment
    {
        public int AssignmentId { get; set; }
        public string AssignmentName { get; set; } = string.Empty;
        public string AssignmentDescription { get; set; } = string.Empty;
        public double? AssignmentMaxValue { get; set; } = null;
        public double? AssignmentEarnedValue { get; set; } = null;
        public int CourseId { get; set; }

        [JsonIgnore]
        public virtual Course Course { get; set; }
        public virtual AssignmentMaterial[] AssignmentMaterials { get; set; }

        public Assignment() {}
    }
}
