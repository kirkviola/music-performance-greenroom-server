namespace music_performance_greenroom_server.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual IEnumerable<UserGroup> UserGroups { get; set; }

        public Group() 
        {
            this.UserGroups = new List<UserGroup>();
        }
    }
}
