namespace api.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string? User { get; set; }
        public string? PasswordHash { get; set; }

        public List<NoteModel> Notes { get; set; }
    }
}
