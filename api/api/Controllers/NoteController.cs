using api.Models;
using api.Repositorys.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using api.Views;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INoteRepository _noteRepository;

        public NotesController(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddNote([FromForm] NoteViewModel note)
        {
            var addedNote = await _noteRepository.addNoteAsync(note);
            return Ok(addedNote);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNotes()
        {
            var notes = await _noteRepository.getAllNotesAsync();
            return Ok(notes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNoteById(int id)
        {
            var note = await _noteRepository.getNoteByIdAsync(id);
            if (note == null)
            {
                return NotFound("Nota não encontrada.");
            }
            return Ok(note);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNote(int id)
        {
            var result = await _noteRepository.removeNoteAsync(id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNote(int id, [FromForm] NoteViewModel note)
        {
            var updatedNote = await _noteRepository.updateNoteAsync(note, id);
            return Ok(updatedNote);
        }
    }
}
