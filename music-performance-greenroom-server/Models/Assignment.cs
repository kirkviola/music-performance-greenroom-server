using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace music_performance_greenroom_server.Models
{
    public class Assignment
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double? MaxValue { get; set; } = null;
        public double? EarnedValue { get; set; } = null;
        [Timestamp]
        public DateTime ChangeTime { get; set; } = DateTime.Now;
        public int CourseId { get; set; }

        [JsonIgnore]
        public virtual Course Course { get; set; }
        public virtual IEnumerable<Material> Materials { get; set; }

        public Assignment() {}
    }
}
