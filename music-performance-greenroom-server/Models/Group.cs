namespace music_performance_greenroom_server.Models
{
    public class Group
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }

        public virtual UserGroup[] UserGroups { get; set; }

        public Group() { }
    }
}
