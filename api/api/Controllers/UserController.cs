using api.Models;
using api.Repositorys.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> GetUsers()
        {
            try
            {
                var users = await _userRepository.getAllUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao buscar usuários: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetUser(int id)
        {
            try
            {
                var user = await _userRepository.getUserById(id);

                if (user == null)
                {
                    return NotFound($"Usuário com ID {id} não encontrado.");
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao buscar usuário: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> PostUser(UserModel user)
        {
            try
            {
                var createdUser = await _userRepository.addUser(user);
                return CreatedAtAction(nameof(GetUser), new { id = createdUser.Id }, createdUser);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao adicionar usuário: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> PutUser(int id, UserModel user)
        {
            try
            {
                var updatedUser = await _userRepository.updateUser(user, id);
                return Ok(updatedUser);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao atualizar usuário: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteUser(int id)
        {
            try
            {
                var message = await _userRepository.removeUser(id);
                return Ok(message);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao remover usuário: {ex.Message}");
            }
        }
    }
}
