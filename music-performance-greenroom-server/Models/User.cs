namespace music_performance_greenroom_server.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public virtual UserCourse[] UserCourses { get; set; }
        public virtual UserMaterial[] UserMaterials { get; set; }
        public virtual UserGroup[] UserGroups { get; set; }
        public virtual UserPermission[] UserPermissions { get; set; }

        public User() {}
    }
}
