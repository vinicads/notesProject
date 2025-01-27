using api.Data;
using api.Models;
using api.Repositorys.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.IO;
using api.Views;

namespace api.Repositorys
{
    public class NoteRepository : INoteRepository
    {
        private readonly NotesDBContext _dbContext;
        private readonly string _storagePath = Path.Combine(Directory.GetCurrentDirectory(), "Files");

        public NoteRepository(NotesDBContext notesDBContext)
        {
            _dbContext = notesDBContext;
        }

        public async Task<NoteModel> addNoteAsync(NoteViewModel note)
        {
            var file = note.filePath;
            var newNote = new NoteModel();
            newNote.Name = note.Name;
            newNote.Description = note.Description;
            newNote.UserId = note.UserId;
            if (file != null)
            {
                if (!Directory.Exists(_storagePath))
                {
                    Directory.CreateDirectory(_storagePath);
                }

                var filePath = Path.Combine(_storagePath, file.FileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                newNote.filePath = filePath;
            }

            await _dbContext.Notes.AddAsync(newNote);
            await _dbContext.SaveChangesAsync();

            return newNote;
        }

        public async Task<List<NoteModel>> getAllNotesAsync()
        {
            return await _dbContext.Notes.ToListAsync();
        }

        public async Task<NoteModel> getNoteByIdAsync(int id)
        {
            return await _dbContext.Notes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<string> removeNoteAsync(int id)
        {
            var note = await getNoteByIdAsync(id);
            if (note == null)
            {
                throw new Exception("Nota não encontrada.");
            }

            if (File.Exists(note.filePath))
            {
                File.Delete(note.filePath);
            }

            _dbContext.Notes.Remove(note);
            await _dbContext.SaveChangesAsync();

            return "Nota excluída com sucesso!";
        }

        public async Task<NoteModel> updateNoteAsync(NoteViewModel note, int id)
        {
            var existingNote = await getNoteByIdAsync(id);
            if (existingNote == null)
            {
                throw new Exception("Nota não encontrada.");
            }

            existingNote.Name = note.Name;
            existingNote.Description = note.Description;
            var file = note.filePath;
            if (file != null)
            {
                if (File.Exists(existingNote.filePath))
                {
                    File.Delete(existingNote.filePath);
                }

                var newFilePath = Path.Combine(_storagePath, file.FileName);

                using (var fileStream = new FileStream(newFilePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                existingNote.filePath = newFilePath;
            }

            _dbContext.Notes.Update(existingNote);
            await _dbContext.SaveChangesAsync();

            return existingNote;
        }
    }
}
