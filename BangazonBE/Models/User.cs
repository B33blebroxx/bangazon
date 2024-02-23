namespace BangazonBE.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string ProfileImgUrl { get; set; }
        public bool IsSeller { get; set; }
        public string Uid { get; set; }
    }
}
