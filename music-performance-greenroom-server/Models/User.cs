namespace music_performance_greenroom_server.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public virtual IEnumerable<UserCourse> UserCourses { get; set; }
        public virtual IEnumerable<Material> Materials { get; set; }
        public virtual IEnumerable<UserGroup> UserGroups { get; set; }
        public virtual IEnumerable<UserPermission> UserPermissions { get; set; }

        public User() 
        {
            this.UserCourses = new List<UserCourse>();
            this.Materials = new List<Material>();
            this.UserGroups = new List<UserGroup>();
            this.UserPermissions = new List<UserPermission>();
        }
    }
}
