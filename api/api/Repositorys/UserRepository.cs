using api.Data;
using api.Models;
using api.Repositorys.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repositorys
{
    public class UserRepository : IUserRepository
    {
        private readonly NotesDBContext _dbContext;
        public UserRepository(NotesDBContext notesDBContext) {
            _dbContext = notesDBContext;
        }

        public async Task<List<UserModel>> getAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserModel> getUserById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UserModel> addUser(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<UserModel> updateUser(UserModel user, int id)
        {
            UserModel userById = await getUserById(id);
            if (userById == null)
            {
                throw new Exception("O usuario com o id enviado nao foi encontrado.");
            }

            userById.User = user.User;
            userById.PasswordHash = user.PasswordHash;

            _dbContext.Users.Update(userById);
            await _dbContext.SaveChangesAsync();
            return userById;
        }

        public async Task<string> removeUser(int id)
        {
            UserModel userById = await getUserById(id);
            if (userById == null)
            {
                throw new Exception("O usuario com o id enviado nao foi encontrado.");
            }

            var notes = await _dbContext.Notes.Where(n => n.UserId == id).ToListAsync();
            if (notes.Any())
            {
                _dbContext.Notes.RemoveRange(notes);
            }

            _dbContext.Users.Remove(userById);
            await _dbContext.SaveChangesAsync();

            return "Usuario apagado!";
        }
    
    }
}
