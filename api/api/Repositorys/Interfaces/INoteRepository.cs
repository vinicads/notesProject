using api.Models;
using api.Views;

namespace api.Repositorys.Interfaces
{
    public interface INoteRepository
    {
        Task<List<NoteModel>> getAllNotesAsync();

        Task<NoteModel> getNoteByIdAsync(int id);

        Task<NoteModel> addNoteAsync(NoteViewModel note);

        Task<NoteModel> updateNoteAsync(NoteViewModel note, int id);

        Task<string> removeNoteAsync(int id);
    }
}
