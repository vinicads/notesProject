namespace api.Views
{
    public class NoteViewModel
    {

        public string Name { get; set; }
        public string? Description { get; set; }
        public int UserId { get; set; }
        public IFormFile filePath { get; set; }
    }
}
