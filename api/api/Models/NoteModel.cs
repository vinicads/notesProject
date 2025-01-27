namespace api.Models
{
    public class NoteModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? filePath { get; set; }

        public int UserId { get; set; }
        public UserModel User { get; set; }
    }
}
